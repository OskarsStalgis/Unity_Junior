using UnityEngine;


public class OnCollisionJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 11f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            GameManager.Instance.LooseLife();
        }
    }

}
