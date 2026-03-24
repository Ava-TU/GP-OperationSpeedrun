using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;
using System.Collections;
using System.Collections.Generic;

//game status data structure
[Serializable]
public struct GameStatus
{
    public string playerName;
    public int currentLevel;
    public float previousTime;
    public float bestTime;
    public int playerHealth;
    public int stars;
    public Vector3 playerPosition;
}

public class GameManagerScript : MonoBehaviour
{
    public GameStatus gameStatus;
    string filePath;
    const string FILE_NAME = "SaveStatus.json";
    //build our UI controls- a simple label

    [SerializeField]
    public PlayerScript player;

    [SerializeField]
    public TimerScript timer;

    public void ShowStatus()
    {
        //building the formatted string to be shown to the user
        string message = "";
        message += "Player Name: " + gameStatus.playerName + "\n";
        message += "Current Level: " + gameStatus.currentLevel + "\n";
        message += "Previous Time: " + gameStatus.previousTime + "\n";
        message += "Best Time: " + gameStatus.bestTime + "\n";
        message += "Player Health: " + gameStatus.playerHealth + "\n";
        message += "Stars: " + gameStatus.stars + "\n";
        message += "Player Position: " + gameStatus.playerPosition + "\n";
        GetComponent<TMP_Text>().text = message;
    }
    //this function emulates a random game event that changes the player's statistics
    public void NewGameStatus()
    {
        //this will create a new game
        gameStatus.playerName = "Subject 17";
        gameStatus.currentLevel = 1;
        gameStatus.previousTime = 0;
        gameStatus.bestTime = 0;
        gameStatus.playerHealth = player.GetComponent<PlayerScript>().maxHealth;
        player.health = gameStatus.playerHealth;
        gameStatus.playerPosition = new Vector3(0, 0, 0);
        GameObject.Find("Player").transform.position = gameStatus.playerPosition;
        gameStatus.stars = 0;

        SaveGameStatus();
        
 
    }

    //this function loads a saving file if found
    public void LoadGameStatus()
    {
        //always check the file exists
        if (File.Exists(filePath + "/" + FILE_NAME))
        {
            //load the file content as string
            string loadedJson = File.ReadAllText(filePath + "/" + FILE_NAME);
            //deserialise the loaded string into a GameStatus struct
            gameStatus = JsonUtility.FromJson<GameStatus>(loadedJson);
            player.health = gameStatus.playerHealth;
            timer.previousTime = gameStatus.previousTime;
            timer.bestTime = gameStatus.bestTime;
            GameObject.Find("Player").transform.position = gameStatus.playerPosition;

            Debug.Log("File loaded successfully");
        }
        else
        {
            
        }
    }

    //this function overrides the saving file
    public void SaveGameStatus()
    {
        //serialise the GameStatus struct into a Json string
        string gameStatusJson = JsonUtility.ToJson(gameStatus);
        //write a text file containing the string value as simple text
        File.WriteAllText(filePath + "/" + FILE_NAME, gameStatusJson);
        Debug.Log("File created and saved");
        gameStatus.playerPosition = GameObject.Find("Player").transform.position;
        gameStatus.previousTime = timer.previousTime;
        gameStatus.bestTime = timer.bestTime;

    }

    // Use this for initialization
    public void Start()
    {

        //retrieving saving location
        filePath = Application.persistentDataPath;
        gameStatus = new GameStatus();
        Debug.Log(filePath);
        //startup initialisation
        LoadGameStatus();
    }
    // Update is called once per frame
    public void Update()
    {
        ShowStatus();
    }
}