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

        //GameManager scriptine ulaþmak için Game Manager objesini bulur.
        gameManagerObj = GameObject.Find("Game Manager");
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();
        

    }

    void Update()
    {
        ballPositionReset();
    }

    // Score duvarlarýndan birine temas edip etmediðinin tespiti.
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

    // AI Score'u alýr ise top'un pozisyonu sýfýrlanýp tekrardan random bir atýþla baþlar ve AI'ýn score puaný 1 arttýrýlýr.
    void AIScoreUpdate()
    {
        transform.position = new Vector2(0, 0);
        ballMoveVectorControl();
        gameManagerScript.AIScore++;
    }
    // Playere Score'u alýr ise top'un pozisyonu sýfýrlanýp tekrardan random bir atýþla baþlar ve Player'ýn score puaný 1 arttýrýlýr.
    void PlayerScoreUpdate()
    {
        transform.position = new Vector2(0, 0);
        ballMoveVectorControl();
        gameManagerScript.playerScore++;
    }

    // Baþlangýç durumunda top'u rastgele bir yönde hareket ettirir.
    public void ballMoveVectorControl()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        ballMoveVector = new Vector2(x, y);
        ballRb.velocity = ballMoveVector * gameManagerScript.ballSpeed;
    }

    // Oyun durdurulduðunda topun konumunu sýfýrlar.
    void ballPositionReset()
    {
        if (!gameManagerScript.isPlay)
        {
            transform.position = new Vector2(0, 0);
        }
    }
}
