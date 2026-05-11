using System.Threading;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked; //Hides and locks cursor to center of view
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

