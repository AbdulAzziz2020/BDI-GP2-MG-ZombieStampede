using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver = false;

    [Header("Panels")] 
    public TMP_Text scoreInGame, scoreInPanel;
    public Image healthBar;
    public Button buttonRestart;
    public GameObject GameOverPanel, crossHair;

    public void Start()
    {
        ScoreUpdating();
    }

    public void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    public void GameOver()
    {
        isGameOver = !isGameOver;
        GameOverPanel.SetActive(isGameOver);    
    }

    public void ScoreUpdating()
    {
        scoreInGame.text = $"Kills = {DataCounter.score}";
        scoreInPanel.text = $"Your Score {DataCounter.score}";
    }
    
    private void OnEnable()
    {
        buttonRestart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
            DataCounter.score = 0;
        });
    }

    private void OnDisable()
    {
        buttonRestart.onClick.RemoveListener(() =>
        {
            SceneManager.LoadScene("Game");
            DataCounter.score = 0;
        });
    }
#if UNITY_STANDALONE
    private void Update()
    {
        PointerUtility();
    }
#endif

    public void UpdateHealthBar(int baseHealth, int curHealth)
    {
        healthBar.fillAmount = (float)curHealth / (float)baseHealth;
    }

    public void PointerUtility()
    {
        Cursor.visible = false;
        crossHair.SetActive(true);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crossHair.transform.position = mousePosition;
    }
}
