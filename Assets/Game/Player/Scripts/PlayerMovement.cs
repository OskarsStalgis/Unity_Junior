using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 200f;
    [SerializeField] private float jumpForce = 6.2f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private AudioSource onHitAudio;
    private Rigidbody2D rb;
    private PlayerInputActions playerInput;


    public bool isPlayerDead = false;
    public bool isHit = false;
    public float hitTimer = 0f;
    public float hitDuration = 0.5f;


    private void Awake()
    {
        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += JumpAction;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isPlayerDead)
        {
            float axis = playerInput.Player.HorizontalMovement.ReadValue<float>();

            rb.linearVelocity = new Vector2(axis * Time.deltaTime * movementSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private bool IsGrounded()
    {
        if (playerCollider == null)
            return false;

        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void JumpAction(InputAction.CallbackContext context)
    {
        if (IsGrounded() && !isPlayerDead)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void ResetHitTimer()
    {
        isHit = true;
    }

    public void OnHit()
    {
        onHitAudio.Play();
    }
}
