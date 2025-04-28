using UnityEngine;

public class RLPlayerMovement : MonoBehaviour
{
    [Header("Movement")]   
    public float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;



    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    
    Rigidbody rb;

    private void Start()
    {
         rb = GetComponent<Rigidbody>();
         rb.freezeRotation = true;
    }
// Update is called once per frame
    void Update()
    {
        // Enhanced debug visualization
        Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.3f), 
                    grounded ? Color.green : Color.red);
        
        // Display current velocity in console
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Current Velocity: " + rb.linearVelocity);
        }


        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        
        MyInput();
        SpeedControl();
    
        // Proper drag handling
        if(grounded)
            rb.linearDamping = groundDrag;
        else 
            rb.linearDamping = 0;
    
    }

    private void FixedUpdate(){
        MovePlayer();
    }
    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        //when to jump
        if(Input.GetKeyDown(jumpKey) &&  readyToJump && grounded){
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump),jumpCooldown);
        }
    }
    
    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }

    private void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.linearVelocity.x,0f,rb.linearVelocity.z);
        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed){
            Vector3 limitedVel = flatVel.normalized*moveSpeed;
            rb.linearVelocity= new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
     }

     private void Jump(){
    // Cancel any existing vertical velocity
    rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
    
    // Apply jump force with more control
    rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
    
    // Optional: Add small forward momentum if moving
    if (moveDirection.magnitude > 0.1f)
    {
        rb.AddForce(moveDirection.normalized * jumpForce * 0.1f, ForceMode.Impulse);
    }
}

     private void ResetJump(){
        readyToJump = true;
     }
}
