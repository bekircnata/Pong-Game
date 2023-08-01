using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Vector2 playerMoveVector;

    private float verticalInput;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerControl();
    }

    void PlayerControl()
    {
        verticalInput = Input.GetAxisRaw("Vertical"); // Inputtan giriþ verisi alýnýr. (Aþaðý ok/S = -1, Yukarý Ok/W = 1)
        playerMoveVector = new Vector2(0, verticalInput); // Player hareket edeceði vector belirlenir.
        playerRb.velocity = playerMoveVector * speed; // Player'ýn gideceði yön ve hýz çarpýlarak hareket saðlanýr.
    }
}
