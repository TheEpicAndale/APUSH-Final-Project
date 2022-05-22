using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject player;
    public string[] playerNames = {"Person 1", "Steamboat", "Person 2"};
    public int playerNum = 0;
    public bool isGameActive;
    public string nameOfSwitchScene;
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
            player = GameObject.Find(playerNames[1]);
            playerNum += 1;
        }

        if(playerNum == 1){
            playerSwitch = player.GetComponent<SteamboatController>().playerSwitch;
        }


        if(playerSwitch == true && playerNum == 1){
            player = GameObject.Find(playerNames[2]);
            playerNum += 1;
        }

        if(playerNum == 2){
            playerSwitch = player.GetComponent<Player2Controller>().playerSwitch;
        }
    }

    public void StartGame()
    {
        // isGameActive = true;
        // titleScreen.SetActive(false);
        SceneManager.LoadScene(nameOfSwitchScene);
    }
}
