using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScriptMulti : MonoBehaviour
{
    [Header("Player Stats")]
    public int currentStars;
    public int maxStars;
    public int damage;
   

    [SerializeField]
    public TMP_Text starsDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starsDisplay = GameObject.Find("starsUI").GetComponent<TMP_Text>();
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("Star"))
            {
                Destroy(col.gameObject);
                currentStars++;
            }
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
