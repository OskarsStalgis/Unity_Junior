using UnityEngine;
using TMPro;
using UnityEditor.UI;

//Created this so the life score saves when switching levels.
public class LifeManager : MonoBehaviour
{
    public TMP_Text lifeText;
    public static int lifeCount = 3;

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Lives: " + lifeCount;
    }
}
