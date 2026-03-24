using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public int health;
   

    [SerializeField]
    TMP_Text healthDisplay;

    [SerializeField]
    GameManagerScript gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;

        gm.Start();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health: " + health;

        if (health <= 0)
        {
            health = 0;
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.name == "Star")
            {
                Destroy(col.gameObject);
                gm.gameStatus.stars += 1;
            }
        }
    }
}
