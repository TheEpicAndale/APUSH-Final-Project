using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplayer : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRb;
    public GameObject pressE;
    public GameObject pressF;
    public string[] texts = {"Text 1", "Text 2", "Text 3"};
    public int playerNum = 0;
    public bool inTextMode = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Game Manager").GetComponent<PlayerSwitcher>().player;
        pressE = GameObject.Find("Press E");
        pressF = GameObject.Find("Press F");
        // text1 = GameObject.Find("");
        // text2 = GameObject.Find("");
        // text3 = GameObject.Find("");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Game Manager").GetComponent<PlayerSwitcher>().player;
        playerRb = player.GetComponent<Rigidbody2D>();

        if(IsReadyToSwitch() == true) 
        {
            FindInActiveObjectByName("Press F").SetActive(true);
        } 
        else 
        {
            FindInActiveObjectByName("Press F").SetActive(false);
        }

        if(IsNextToText() == true && inTextMode == true) 
        {
            FindInActiveObjectByName("Press E").SetActive(false);
            FindInActiveObjectByName(texts[playerNum]).SetActive(true);
        } 
        else if(IsNextToText() == true)
        {
            FindInActiveObjectByName("Press E").SetActive(true);
            FindInActiveObjectByName(texts[playerNum]).SetActive(false);
        }
        else 
        {
            FindInActiveObjectByName("Press E").SetActive(false);
        }
    }

    bool IsReadyToSwitch()
    {
        if(playerRb.position.x >= 4 && playerRb.position.x <= 7)
        {
            return true;
        } 
        else if(playerRb.position.x >= 18.5 && playerRb.position.x <= 19.5)
        {
            return true;
        }
        else if (playerRb.position.x >= 23 && playerRb.position.x <= 25) 
        {
            return true;
        } 
        else 
        {
            return false;
        }
    }

    bool IsNextToText()
    {
        if (playerRb.position.x <= 2)
        {
            InTextMode();
            return true;
        }
        else if(playerRb.position.x >= 18.5 && playerRb.position.x <= 19.5)
        {
            InTextMode();
            playerNum = 1;
            return true;
        }
        else if (playerRb.position.x >= 34)
        {
            InTextMode();
            playerNum = 2;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InTextMode()
    {
        if(Input.GetKey(KeyCode.E))
            {
                inTextMode = true;
            }
            else if(Input.GetKey(KeyCode.Escape))
            {
                inTextMode = false;
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