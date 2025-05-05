using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    public Vector3 offset = new Vector3(0f, 3f, -4);  

    void LateUpdate()
    {
        Vector3 desiredPosition = character.position + offset;
        transform.position = desiredPosition;

        transform.LookAt(character);
    }
}
