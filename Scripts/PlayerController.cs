using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;
    public float jumpCooldown = 0.3f; // Cooldown duration in seconds
    public AudioClip jumpSound;  

    private AudioSource audioSource;
    private Rigidbody rb;
    private Collider coll;
    private bool readyToJump = true;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        WalkHandler();
        JumpHandler();
    }

    void WalkHandler()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(hAxis * walkSpeed, rb.linearVelocity.y, vAxis * walkSpeed);
        rb.linearVelocity = movement;
    }

    void JumpHandler()
    {
        if(Input.GetButtonDown("Jump") && readyToJump && CheckGrounded())
        {
            readyToJump = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);
            
            if (jumpSound != null && audioSource != null)
                audioSource.PlayOneShot(jumpSound);
                
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void ResetJump()
    {
        readyToJump = true;
    }

    bool CheckGrounded()
    {
        float checkDistance = 0.2f;
        Vector3 position = transform.position + Vector3.down * (coll.bounds.extents.y + 0.1f);
        return Physics.CheckSphere(position, 0.1f, LayerMask.GetMask("Default")); 
    }
}