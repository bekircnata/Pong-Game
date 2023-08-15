using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI AIScoreText;
    [SerializeField]  private GameObject ballObj;
    [SerializeField] private GameObject easyButton;
    [SerializeField] private GameObject mediumButton;
    [SerializeField] private GameObject hardButton;

    public int playerScore = 0;
    public int AIScore = 0;
    public bool isPlay = false;
    public int playerSpeed;
    public int playerAISpeed;
    public int ballSpeed;

    void Start()
    {
       
    }

    void Update()
    {
        playerScoreText.text = playerScore.ToString();
        AIScoreText.text = AIScore.ToString();

        MenuOff();
        GameEnd();
    }

    public void EasyStartGame()
    {
        playerSpeed = 5;
        playerAISpeed = 5;
        ballSpeed = 6;
        GameStart();
    }
    public void MediumStartGame()
    {
        playerSpeed = 8;
        playerAISpeed = 9;
        ballSpeed = 10;
        GameStart();
    }
    public void HardStartGame()
    {
        playerSpeed = 10;
        playerAISpeed = 11;
        ballSpeed = 12;
        GameStart();
    }

    // Oyun baþladýðýnda menüyü kaldýrýr.
    void MenuOff()
    {
         easyButton.SetActive(!isPlay);
         mediumButton.SetActive(!isPlay);
         hardButton.SetActive(!isPlay);
    }

    void GameStart()
    {
        isPlay = true;
        Time.timeScale = 1;
        ballObj.GetComponent<BallController>().ballMoveVectorControl();
    }

    // ESC tuþu ile oyun bitirilir.
    void GameEnd()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPlay = false;
            playerScore = 0;
            AIScore = 0;
            Time.timeScale = 0;
        }
    }

}
