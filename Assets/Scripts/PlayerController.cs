using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Vector2 playerMoveVector;
    private GameObject gameManagerObj;
    private GameManager gameManagerScript;

    private float verticalInput;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        //GameManager scriptine ula�mak i�in Game Manager objesini bulur.
        gameManagerObj = GameObject.Find("Game Manager");
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManagerScript.isPlay)
        {
            PlayerControl();
        }
    }

    void PlayerControl()
    {
        verticalInput = Input.GetAxisRaw("Vertical"); // Inputtan giri� verisi al�n�r. (A�a�� ok/S = -1, Yukar� Ok/W = 1)
        playerMoveVector = new Vector2(0, verticalInput); // Player hareket edece�i vector belirlenir.
        playerRb.velocity = playerMoveVector * gameManagerScript.playerSpeed; // Player'�n gidece�i y�n ve h�z �arp�larak hareket sa�lan�r.
    }
}
