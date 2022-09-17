using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maximumHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        currentHealth = maximumHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            ProcessDeath();
        }
        UpdateHealthUI();
    }

    private void ProcessDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    private void UpdateHealthUI()
    {
        healthText.text = "HP: " + currentHealth.ToString();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
