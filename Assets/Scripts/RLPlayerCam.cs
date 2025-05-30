using UnityEngine;

public class RLPlayerCam : MonoBehaviour
{
public float sensX;
public float sensY;

public Transform orientation;

float xRotation;
float yRotation;

private void State(){
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

private void Update(){
    //get mouse input
    float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;
    
    yRotation += mouseX;
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation,-90f,90f);

    //rotation cam and orientation
    transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
    orientation.rotation = Quaternion.Euler(0,yRotation,0);
}
}
