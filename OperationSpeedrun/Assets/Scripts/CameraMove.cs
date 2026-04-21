using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public Transform lookAt;

    public Transform player;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensitivity = 4.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentX += Input.GetAxis("MouseX") * sensitivity * Time.deltaTime;
        currentY += Input.GetAxis("MouseY")* sensitivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMax, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;

        transform.LookAt(lookAt.position);
    }
}
