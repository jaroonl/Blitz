using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    public Vector3 offset = new Vector3(0f, 0.05f, -0.01f);  

    void LateUpdate()
    {
        Vector3 desiredPosition = character.position + offset;
        transform.position = desiredPosition;

        Debug.Log("CameraFollow running: character=" + character.name +
                  " | offset=" + offset +
                  " | setting camera.position=" + desiredPosition);

        transform.LookAt(character);
    }
}
