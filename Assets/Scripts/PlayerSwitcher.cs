using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player;
    public string[] playerNames = {"Person 1", "Steamboat", "Person 2"};
    public int playerNum = 0;
    public bool playerSwitch;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(playerNames[playerNum]);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNum == 0){
            playerSwitch = player.GetComponent<Player1Controller>().playerSwitch;
        }
        
        if(playerSwitch == true && playerNum == 0){
            player.SetActive(false);
            player = GameObject.Find(playerNames[1]);
            FindInActiveObjectByName(playerNames[2]).SetActive(false);
            playerNum += 1;
        }

        if(playerNum == 1){
            playerSwitch = player.GetComponent<SteamboatController>().playerSwitch;
        }


        if(playerSwitch == true && playerNum == 1){
            FindInActiveObjectByName(playerNames[2]).SetActive(true);
            player = GameObject.Find(playerNames[2]);
            playerNum += 1;
        }
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
