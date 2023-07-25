using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Vector2 playerMoveVector;

    private float verticalInput;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }

    void PlayerControl()
    {
        verticalInput = Input.GetAxisRaw("Vertical"); // Inputtan giriþ verisi alýnýyor. (Aþaðý ok = -1, Yukarý Ok = 1)
        playerMoveVector = new Vector2(0, verticalInput); // Player hareket edeceði vector belirleniyor.
        playerRb.velocity = playerMoveVector * speed; // Player'ýn gideceði yön ve hýz çarpýlarak hareket saðlanýyor.
    }
}
