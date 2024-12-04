using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class LevelTimer : MonoBehaviour
{
    public float levelTime = 60f; 
    public TextMeshProUGUI timerText; 
    public GameEnding gameEnding;

    private bool timerExpired = false; 

    void Start()
    {
        
        if (gameEnding == null)
        {
            gameEnding = FindObjectOfType<GameEnding>();
            if (gameEnding == null)
            {
                Debug.LogError("GameEnding script not found! Please assign it in the Inspector.");
            }
        }
    }

    void Update()
    {
        if (timerExpired) return; 

        
        levelTime -= Time.deltaTime;

        
        int minutes = Mathf.FloorToInt(levelTime / 60f);
        int seconds = Mathf.FloorToInt(levelTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";

        
        if (levelTime <= 0)
        {
            timerText.text = "00:00";
            TimerExpired(); 
        }
    }

    void TimerExpired()
    {
        timerExpired = true;

        if (gameEnding != null)
        {
            
            gameEnding.CaughtPlayer();
        }
        else
        {
            Debug.LogError("GameEnding reference is missing or not set!");
        }
    }
}