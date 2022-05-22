using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3[] defaultOffset = {new Vector3(0, 2.8f, -15), new Vector3(-1, 2.4f, -15), new Vector3(0, 2.8f, -15)};
    Vector3 offset;
    public Vector3 secondOffset;
    public int defaultOffsetNum;
    public double leftBounds = -5.5;
    public double rightBounds = 46.5;


    // Start is called before the first frame update
    void Start()
    {
        offset = defaultOffset[0];
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Game Manager").GetComponent<PlayerSwitcher>().player;
        defaultOffsetNum = GameObject.Find("Game Manager").GetComponent<PlayerSwitcher>().playerNum;
        if(player.transform.position.x > leftBounds && player.transform.position.x < rightBounds){
            transform.position = player.transform.position + offset + secondOffset;
            offset = defaultOffset[defaultOffsetNum];
        }
    }
}
