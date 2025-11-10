using UnityEngine;
using UnityEditor.UI;
using TMPro;

//Created this so the life score saves when switching levels.
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public static int scoreCount;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreCount;
    }
}
