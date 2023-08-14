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

        if(isPlay)
        {
            easyButton.SetActive(false);
            mediumButton.SetActive(false);
            hardButton.SetActive(false);
        }
    }

    public void EasyStartGame()
    {
        isPlay = true;
        playerSpeed = 5;
        playerAISpeed = 5;
        ballSpeed = 6;
        ballObj.GetComponent<BallController>().ballMoveVectorControl();
    }
    public void MediumStartGame()
    {
        isPlay = true;
        playerSpeed = 8;
        playerAISpeed = 9;
        ballSpeed = 10;
        ballObj.GetComponent<BallController>().ballMoveVectorControl();
    }
    public void HardStartGame()
    {
        isPlay = true;
        playerSpeed = 10;
        playerAISpeed = 11;
        ballSpeed = 12;
        ballObj.GetComponent<BallController>().ballMoveVectorControl();
    }
}
