using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Rigidbody2D playerAIRb;
    [SerializeField] private GameObject ball;
    private Vector2 playerAIMoveVector;

    [SerializeField] private float speed = 5f;

    void Start()
    {
        playerAIRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerAIControl();
    }

    private void PlayerAIControl()
    {
        // Topun konumuna göre playerAI'ýn aþaðý yönde mi yukarý yönde mi hareket edeceði belirleniyor.
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerAIMoveVector = new Vector2(0, 1);
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerAIMoveVector = new Vector2(0, -1);
        }
        else
        {
            playerAIMoveVector = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        playerAIRb.velocity = playerAIMoveVector * speed;
    }
}
