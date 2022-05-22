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
    public bool inTextMode = false;
    public double isOnBoundaryLeftBound = 30;
    public double isOnBoundaryRightBound = 57;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onPlayer == true)
        {
            horizontal = Input.GetAxis("Horizontal");
        }
    }

    void FixedUpdate()
    {
        inTextMode = GameObject.Find("Text Displayer").GetComponent<TextDisplayer>().inTextMode;
        if(IsOnBoundary() == false && onPlayer == true) {
            position = playerRb.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            playerRb.MovePosition(position);
        }

        if(GameObject.Find("Game Manager").GetComponent<PlayerSwitcher>().playerNum == 2){
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

    bool IsOnBoundary()
    {
        if(position.x <= isOnBoundaryLeftBound && horizontal < 0){
            return true;
        }

        if(position.x >= isOnBoundaryRightBound && horizontal > 0){
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
