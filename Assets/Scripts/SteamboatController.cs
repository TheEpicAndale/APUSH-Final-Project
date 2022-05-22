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
    public bool canPassHalfway = true;
    public double canPassHalfwayLeftBound = 18.5;
    public double canPassHalfwayRightBound = 19.5;
    public bool isPassHalfway = false;
    public double isReadyToSwitchLeftBound = 23;
    public double isReadyToSwitchRightBound = 25;
    public double isOnBoundaryBound = 24;

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
        if(IsOnBoundary() == false && onPlayer == true && canPassHalfway == true) {
            position = playerRb.position;
            position.x = position.x + speed * Time.deltaTime;
            playerRb.MovePosition(position);
        }
        CanPassHalfway();
        if(IsReadyToSwitch() == true && Input.GetKey(KeyCode.F)){
            playerSwitch = true;
        }

        if(GameObject.Find("Game Manager").GetComponent<PlayerSwitcher>().playerNum == 1){
            onPlayer = true;
        } else {
            onPlayer = false;
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
        if(position.x >= isOnBoundaryBound){
            return true;
        }
        else
        {
            return false;
        }
    }
    
    void CanPassHalfway()
    {
        if(position.x > canPassHalfwayLeftBound && position.x < canPassHalfwayLeftBound + 1 && isPassHalfway == false)
        {
            if(Input.GetKey(KeyCode.F))
            {
                canPassHalfway = true;
                isPassHalfway = true;
            }
            else
            {
                canPassHalfway = false;
            }
        }
    }
}
