using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource onCollectAudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.gameObject.tag == player.tag)
        {
            animator.SetTrigger("Collected");
        }
    }

    public void OnCollect()
    {
        GameManager.Instance.GainLife();
        Destroy(gameObject);
    }

    public void OnCollectAudio()
    {
        onCollectAudioSource.Play();
    }

}
