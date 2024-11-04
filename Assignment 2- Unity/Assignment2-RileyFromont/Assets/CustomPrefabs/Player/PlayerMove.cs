using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speedFactor = 10f;
    [Range(0f, 50f)]
    public float maxSpeed = 30f;
    public InputActionReference movement;
    public InputActionReference jump;

    public bool gravity_enabled = true;
    public float Gravity_coeff = -9.81f;
    public float jump_height = 3f;
    
    public Transform GroundCollision;
    public float groundDistCheck = 0.3f;
    public LayerMask groundMask;


    public Vector3 velocity;
    private Vector3 vertvelocity;
    public float vel_magnitude;

    private bool LockMove = false;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        if (!LockMove){

            Vector2 moveInput = movement.action.ReadValue<Vector2>();
            isGrounded = Physics.CheckSphere(GroundCollision.position,groundDistCheck,groundMask);
          
            //float x = Input.GetAxis("Horizontal");
            //float z = Input.GetAxis("Vertical");

            //added Deadzone
            if(Mathf.Abs(moveInput.x) < 0.2) {  moveInput.x = 0f; }
            if(Mathf.Abs(moveInput.y) < 0.2) { moveInput.y = 0f; }

            

           

            //controller.Move(movement * speedFactor * Time.deltaTime);
            if (gravity_enabled)
            {

                Vector3 hzmovement = transform.right * moveInput.x;
                Vector3 fwmovement = transform.forward * moveInput.y;

                velocity.x = (hzmovement.x + fwmovement.x);
                velocity.z = (fwmovement.z + hzmovement.z);

                //velocity.Normalize();
                velocity *= speedFactor;
                controller.Move(velocity * Time.deltaTime);

                if (isGrounded && vertvelocity.y < 0f) { vertvelocity.y = 0f; }
               



                if (jump.action.triggered && isGrounded)
                    {
                    vertvelocity.y += Mathf.Sqrt(jump_height*-3.0f*Gravity_coeff);
                }
                //clear GroundCollisionCheck
               

                vertvelocity.y += Gravity_coeff * Time.deltaTime;
                controller.Move(vertvelocity * Time.deltaTime);
            }
            //vel_magnitude = velocity.magnitude;
            
            
        }

    }

    
    public void LockMovement(bool lockMove) {  LockMove = lockMove; }
}
