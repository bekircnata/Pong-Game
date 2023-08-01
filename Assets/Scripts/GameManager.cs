using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI AIScoreText;

    public int playerScore = 0;
    public int AIScore = 0;

    void Start()
    {
        
    }

    void Update()
    {
        playerScoreText.text = playerScore.ToString();
        AIScoreText.text = AIScore.ToString();
    }
}
