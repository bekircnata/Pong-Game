using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private Vector2 ballMoveVector;
    private GameObject gameManagerObj;
    private GameManager gameManagerScript;

    [SerializeField] private AudioSource earnPointSound;
    [SerializeField] private AudioSource losePointSound;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();

        //GameManager scriptine ula�mak i�in Game Manager objesini bulur.
        gameManagerObj = GameObject.Find("Game Manager");
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();
        

    }

    void Update()
    {
        ballPositionReset();
    }

    // Score duvarlar�ndan birine temas edip etmedi�inin tespiti.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerScoreWall"))
        {
            AIScoreUpdate();
            losePointSound.Play();
        }
        else if (collision.CompareTag("AIScoreWall"))
        {
            PlayerScoreUpdate();
            earnPointSound.Play();
        }
    }

    // AI Score'u al�r ise top'un pozisyonu s�f�rlan�p tekrardan random bir at��la ba�lar ve AI'�n score puan� 1 artt�r�l�r.
    void AIScoreUpdate()
    {
        transform.position = new Vector2(0, 0);
        ballMoveVectorControl();
        gameManagerScript.AIScore++;
    }
    // Playere Score'u al�r ise top'un pozisyonu s�f�rlan�p tekrardan random bir at��la ba�lar ve Player'�n score puan� 1 artt�r�l�r.
    void PlayerScoreUpdate()
    {
        transform.position = new Vector2(0, 0);
        ballMoveVectorControl();
        gameManagerScript.playerScore++;
    }

    // Ba�lang�� durumunda top'u rastgele bir y�nde hareket ettirir.
    public void ballMoveVectorControl()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        ballMoveVector = new Vector2(x, y);
        ballRb.velocity = ballMoveVector * gameManagerScript.ballSpeed;
    }

    // Oyun durduruldu�unda topun konumunu s�f�rlar.
    void ballPositionReset()
    {
        if (!gameManagerScript.isPlay)
        {
            transform.position = new Vector2(0, 0);
        }
    }
}
