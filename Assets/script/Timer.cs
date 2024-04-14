using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel; // Référence au panneau Game Over dans l'éditeur Unity
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private float remainingTime;
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (!isGameOver && remainingTime <= 0)
        {
            remainingTime = 0;
            isGameOver = true;
            ShowGameOverPanel();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // Affiche le panneau Game Over
        Time.timeScale = 0; // Met en pause le jeu
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}

