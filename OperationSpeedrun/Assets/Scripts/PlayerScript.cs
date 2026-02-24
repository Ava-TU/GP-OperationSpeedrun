using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    int health;

    [SerializeField]
    TMP_Text healthDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;
        healthDisplay.text = "Health:" + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
