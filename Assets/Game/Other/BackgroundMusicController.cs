using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    private static BackgroundMusicController instance;

    // Makes sure that the background music doesnt loop when reseting the game.
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}

