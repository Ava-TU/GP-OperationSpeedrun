using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public int maxHealth;
   

    [SerializeField]
    public TMP_Text healthDisplay;

    [SerializeField]
    GameManagerScript gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;

        gm.Start();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health: " + gm.gameStatus.playerHealth;

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
