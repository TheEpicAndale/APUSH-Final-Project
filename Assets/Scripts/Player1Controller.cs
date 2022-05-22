using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    float horizontal;
    Rigidbody2D playerRb;
    Vector2 position;
    private float speed = 10;
    public bool playerSwitch = false;
    private bool isFacingRight = true;
    public bool inTextMode = false;
    public double isOnBoundaryLeftBound = -15;
    public double isOnBoundaryRightBound = 6;
    public double isReadyToSwitchLeftBound = 4;
    public double isReadyToSwitchRightBound = 7;

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
        inTextMode = GameObject.Find("Text Displayer").GetComponent<TextDisplayer>().inTextMode;
        if(IsOnBoundary() == false && inTextMode == false) {
            position = playerRb.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            playerRb.MovePosition(position);
        }
        if(IsReadyToSwitch() == true && Input.GetKey(KeyCode.F)){
            playerSwitch = true;
        }

        if (horizontal > 0 && !isFacingRight) {
            Flip();
        } else if (horizontal < 0 && isFacingRight) {
            Flip();
        }
    }

    bool IsReadyToSwitch(){
        if(position.x >= isReadyToSwitchLeftBound && position.x <= isReadyToSwitchRightBound){
            return true;
        }
        return false;
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
