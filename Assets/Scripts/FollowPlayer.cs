using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3[] defaultOffset = {new Vector3(6, 2.8f, -15), new Vector3(3, 3.75f, -15), new Vector3(6, 2.8f, -15)};
    Vector3 offset;
    public Vector3 secondOffset;
    public int defaultOffsetNum;


    // Start is called before the first frame update
    void Start()
    {
        offset = defaultOffset[0];
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Game Manager").GetComponent<GameManager>().player;
        defaultOffsetNum = GameObject.Find("Game Manager").GetComponent<GameManager>().playerNum;
        if(player.transform.position.x < 40.5){
            transform.position = player.transform.position + offset + secondOffset;
            offset = defaultOffset[defaultOffsetNum];
        }
    }
}
