using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    //variables containing input values
    float xMouse, yMouse;

    //customisable mouse sensitivity
    public float mouseXSensitivity, mouseYSensitivity;

    // Update is called once per frame
    void Update()
    {
        //getting mouse input
        xMouse = Input.GetAxis("Mouse X");
        yMouse = Input.GetAxis("Mouse Y");
        
        //change camera rotation based on mouse input
        transform.Rotate(Vector3.up, xMouse * mouseXSensitivity);
        transform.Rotate(Vector3.left, yMouse * mouseYSensitivity);
    }
}

