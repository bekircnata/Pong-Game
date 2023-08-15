using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Rigidbody2D playerAIRb;
    [SerializeField] private GameObject ball;
    private Vector2 playerAIMoveVector;
    private GameObject gameManagerObj;
    private GameManager gameManagerScript;


    void Start()
    {
        playerAIRb = GetComponent<Rigidbody2D>();

        //GameManager scriptine ulaþmak için Game Manager objesini bulur.
        gameManagerObj = GameObject.Find("Game Manager");
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();
    }

    void Update()
    {
        PlayerAIControl();
    }

    // Topun konumuna göre playerAI'ýn aþaðý yönde mi yukarý yönde mi hareket edeceði belirler.
    private void PlayerAIControl()
    {
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
        playerAIRb.velocity = playerAIMoveVector * gameManagerScript.playerAISpeed;
    }
}
