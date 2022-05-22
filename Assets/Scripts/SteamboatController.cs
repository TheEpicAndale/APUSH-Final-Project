using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamboatController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Vector2 position;
    public GameObject textBox;
    private float speed = 4;
    public bool playerSwitch = false;
    public bool onPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if(isOnBoundary() == false && onPlayer == true) {
            position = playerRb.position;
            position.x = position.x + speed * Time.deltaTime;
            playerRb.MovePosition(position);
        }
        if(isReadyToSwitch() == true && Input.GetKey(KeyCode.F)){
            playerSwitch = true;
        }

        if(GameObject.Find("Game Manager").GetComponent<GameManager>().playerNum == 1){
            onPlayer = true;
        } else {
            onPlayer = false;
        }
    }

    bool isReadyToSwitch(){
        if(position.x >= 24 && position.x <= 27){
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
        if(position.x >= 26.5){
            return true;
        }
        return false;
    }
}
