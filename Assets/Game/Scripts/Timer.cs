using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    public static float _currentTime = 0f;

    public bool isActive = false;
    public static Timer Instance { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            _currentTime = _currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);

        timerText.text = "Time: " + time.ToString("mm':'ss");
        }
    
    }
}
