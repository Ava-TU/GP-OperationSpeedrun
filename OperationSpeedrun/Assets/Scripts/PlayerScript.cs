using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public int health;

    [SerializeField]
    TMP_Text healthDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health:" + health;

        if (health <= 0)
        {
            health = 0;
        }
    }
}
