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
    public string spawnPoint;
    public int currentTime;
    public int health;
    public int stars;
}

public class GameManagerScript : MonoBehaviour
{
    public GameStatus gameStatus;
    string filePath;
    const string FILE_NAME = "SaveStatus.json";
    //build our UI controls- a simple label

    public void ShowStatus()
    {
        //building the formatted string to be shown to the user
        string message = "";
        message += "Player Name: " + gameStatus.playerName + "\n";
        message += "Current Level: " + gameStatus.currentLevel + "\n";
        message += "Spawn Point: " + gameStatus.spawnPoint + "\n";
        message += "Current Time: " + gameStatus.currentTime + "\n";
        message += "Health: " + gameStatus.health + "\n";
        message += "Stars: " + gameStatus.stars + "\n";
        GetComponent<TMP_Text>().text = message;
    }
    //this function emulates a random game event that changes the player's statistics
    public void NewGameStatus()
    {
        //this will create a new game
        gameStatus.playerName = "Subject 17";
        gameStatus.currentLevel = 1;
        gameStatus.spawnPoint = "Tutorial";//reference to a game object
        gameStatus.currentTime = 0;
        gameStatus.health = 5;
        gameStatus.stars = 0;
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
            Debug.Log("File loaded successfully");
        }
        else
        {
            //initilise a new game status
            gameStatus.playerName = "Subject 17";
            gameStatus.currentLevel = 1;
            gameStatus.spawnPoint = "Tutorial";//reference to a game object
            gameStatus.currentTime = 0;
            gameStatus.health = 5;
            gameStatus.stars = 0;
            Debug.Log("File not found");
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