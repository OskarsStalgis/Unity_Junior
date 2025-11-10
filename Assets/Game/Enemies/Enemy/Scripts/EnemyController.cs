using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private AudioSource attackAudioSource;
    [SerializeField] private Transform[] points;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float playerPositionOffset = 1f;
    [SerializeField] private float marginOfError = 0.01f;
    [SerializeField] private bool loopPoints;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private int currentPointIndex = 0;
    private int indexStep = -1;

    public bool isTriggered = false;
    public bool isPlayerInAttackRange = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Basically me trying to combine lecture enemy + looping NPC from moving plaform code.
        //It kinda works but can get laggy and sometimes send enemies to random places during gameplay.
        if (points.Length != 0)
        {
            if (isTriggered)
            {
                if (isPlayerInAttackRange)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    animator.Play("Attack");
                }
                else if (player.transform.position.x < transform.position.x + playerPositionOffset)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    rb.linearVelocity = new Vector2(Time.deltaTime * -movementSpeed, rb.linearVelocity.y);
                    spriteRenderer.flipX = false;
                    animator.Play("Move");
                }
                else if (player.transform.position.x > transform.position.x)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    rb.linearVelocity = new Vector2(Time.deltaTime * movementSpeed, rb.linearVelocity.y);
                    spriteRenderer.flipX = true;
                    animator.Play("Move");
                }
            }
            else
            {
                Transform currentPoint = points[currentPointIndex];
                Transform targetPos = currentPoint.transform;

                if (transform.position.x > targetPos.position.x)
                {
                    rb.linearVelocity = new Vector2(Time.deltaTime * -movementSpeed, rb.linearVelocity.y);
                    spriteRenderer.flipX = false;
                    animator.Play("Move");
                }
                else if (transform.position.x < targetPos.position.x)
                {
                    rb.linearVelocity = new Vector2(Time.deltaTime * movementSpeed, rb.linearVelocity.y);
                    spriteRenderer.flipX = true;
                    animator.Play("Move");
                }

                float distance = Vector3.Distance(targetPos.transform.position, transform.position);
                if (distance < marginOfError)
                {
                    if (currentPointIndex == (points.Length - 1) || currentPointIndex == 0)
                    {
                        indexStep = -indexStep;
                    }
                    currentPointIndex += indexStep;
                }
            }

        }
        else if (points.Length == 0)
        {
            if (isTriggered)
            {
                if (isPlayerInAttackRange)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    animator.Play("Attack");
                }
                else if (player.transform.position.x < transform.position.x + playerPositionOffset)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    rb.linearVelocity = new Vector2(Time.deltaTime * -movementSpeed, rb.linearVelocity.y);
                    spriteRenderer.flipX = false;
                    animator.Play("Move");
                }
                else if (player.transform.position.x > transform.position.x)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    rb.linearVelocity = new Vector2(Time.deltaTime * movementSpeed, rb.linearVelocity.y);
                    spriteRenderer.flipX = true;
                    animator.Play("Move");
                }
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
                animator.Play("Idle");
            }
        }
    }
    
    public void AttackPlayer()
    {
        attackAudioSource.Play();
        if (isPlayerInAttackRange)
        {
            GameManager.Instance.LooseLife();
        }
    }
}
