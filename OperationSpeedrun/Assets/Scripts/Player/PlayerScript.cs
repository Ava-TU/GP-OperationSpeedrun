using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Stats")]
    public int health;
    public int maxHealth;
    public int currentStars;
    public int maxStars;
   

    [SerializeField]
    public TMP_Text healthDisplay;
    public TMP_Text starsDisplay;

    [SerializeField]
    public TMP_Text gameStatusUI;
    int numberStars = 10;

    [SerializeField]
    GameManagerScript gm;

    public SO_GameManager gmSO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        currentStars = gm.gameStatus.stars;

        gm.Start();

        UpdateSceneFromManager();

        //gm = GameObject.Find("Canvas/DataText").GameManagerScript;
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health: " + gm.gameStatus.playerHealth;

        if (health <= 0)
        {
            health = 0;
        }
    }

    void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("Star"))
            {
                Destroy(col.gameObject);
                currentStars++;
                gm.gameStatus.stars += 1;
            }
        }

    private void FixedUpdate()
    {
        //Debug.Log (gmSO.gameStatus.playerHealth);

        //check current health level to determine whether player must die!
        if (gmSO.gameStatus.playerHealth <= 0)
        {
            gmSO.resetGame();
        }

        if (gmSO.gameStatus.starsCollected >= numberStars)
        {
            // Reset Gamemanager variuables
            gmSO.resetGame();

        }

        gameStatusUI.text = gmSO.UpdateStatus();
    }

    void OnApplicationQuit()
    {

        // Save Scene Data to the GameManager
        SaveFromSceneToManager();

        //Debug.Log("OnApplicationQuit Called");
    }

     // Save data from the scene to the manager
    void SaveFromSceneToManager()
    {

        // Update Player Position in the GameManager with the position of the Player in the scene
        // This will be stored on the JSON file when the application quits

    }

     void UpdateSceneFromManager()
    {
       
    }
}
