using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector3 startPos;

    private void Start(){

        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Obstacle")){
    
            Die();
        }
    }
    void Die(){
        Respawn();
    }

    void Respawn(){
        transform.position = startPos;
    }
}
