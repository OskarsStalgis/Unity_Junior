using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            SceneManager.LoadScene(gameObject.scene.buildIndex + 1);
        }
    }
}
