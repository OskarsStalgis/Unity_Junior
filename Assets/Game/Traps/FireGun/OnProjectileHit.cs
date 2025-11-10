using UnityEngine;

public class OnProjectileHit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.LooseLife();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Path")
        {
            Destroy(gameObject);
        }
    }
}