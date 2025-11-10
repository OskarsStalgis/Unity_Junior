using UnityEngine;

public class OnCollisionHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.LooseLife();
        }
    }
}
