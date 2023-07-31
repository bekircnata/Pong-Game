using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private Vector2 ballMoveVector;

    [SerializeField] private float speed = 5f;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ballMoveVectorControl();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerScoreWall"))
        {
            AIScoreUpdate();
        }
        else if (collision.CompareTag("AIScoreWall"))
        {
            PlayerScoreUpdate();
        }
    }

    void AIScoreUpdate()
    {
        transform.position = new Vector2(0, 0);
        ballMoveVectorControl();

    }

    void PlayerScoreUpdate()
    {
        transform.position = new Vector2(0, 0);
        ballMoveVectorControl();
    }

    // Baþlangýç durumunda top'u rastgele bir yönde hareket ettirir.
    void ballMoveVectorControl()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        ballMoveVector = new Vector2(x, y);
        ballRb.velocity = ballMoveVector * speed;
    }
}
