using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontal;
    Rigidbody2D playerRb;
    Vector2 position;
    public GameObject textBox;
    private float speed = 10;
    public bool playerSwitch = false;
    public bool onPlayer = false;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if(isOnBoundary() == false && onPlayer == true) {
            position = playerRb.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            playerRb.MovePosition(position);
        }
        if(isReadyToSwitch() == true && Input.GetKey(KeyCode.F)){
            playerSwitch = true;
        }

        if(GameObject.Find("Game Manager").GetComponent<GameManager>().playerNum == 2){
            onPlayer = true;
        } else {
            onPlayer = false;
        }

        if (horizontal > 0 && !isFacingRight) {
            Flip();
        } else if (horizontal < 0 && isFacingRight) {
            Flip();
        }
    }

    bool isReadyToSwitch(){
        if(position.x >= 7 && position.x <= 11){
            return true;
        }
        return false;
    }

    bool isNextToText()
    {
        if(position.x > 3){
            return true;
        }
        return false;
    }

    bool isOnBoundary()
    {
        if(position.x <= 30 && horizontal < 0){
            return true;
        }

        if(position.x >= 57 && horizontal > 0){
            return true;
        }
        return false;
    }

    private void Flip() {
        // Swap direction
        isFacingRight = !isFacingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
