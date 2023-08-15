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

        //GameManager scriptine ulaþmak için Game Manager objesini bulur.
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
        verticalInput = Input.GetAxisRaw("Vertical"); // Inputtan giriþ verisi alýnýr. (Aþaðý ok/S = -1, Yukarý Ok/W = 1)
        playerMoveVector = new Vector2(0, verticalInput); // Player hareket edeceði vector belirlenir.
        playerRb.velocity = playerMoveVector * gameManagerScript.playerSpeed; // Player'ýn gideceði yön ve hýz çarpýlarak hareket saðlanýr.
    }
}
