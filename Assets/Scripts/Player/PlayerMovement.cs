using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public Transform player;
    public Rigidbody playerRB;
    private float speed = 7.0f;
    public bool touchStart = false;
    public Quaternion lookDirection;
    public GameObject childStickman;
    public Animator playerAnimator;
    public Thrower thrower;
    public TrailRenderer trail;
    public GameObject mainMenu;
    public VariableJoystick variableJoystick;


    


    private void Start()
    {
        thrower = FindObjectOfType<Thrower>();
        
    }
    public void Update()
    {
        childStickman.transform.rotation = Quaternion.Slerp(childStickman.transform.rotation, lookDirection, Time.deltaTime * 30);
        if(touchStart == false)
        {
            playerAnimator.SetBool("isWalking",false);
            
          
         

        }if(touchStart == true  )
        {
            playerAnimator.SetBool("isWalking",true);
            
           
            
        }

        
        if((Input.GetMouseButton(0) && mainMenu.activeInHierarchy == false) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) ) && mainMenu.activeInHierarchy == false){
            touchStart = true;
            
        }else{
            touchStart = false;
        }

        if(Input.anyKeyDown){
            if (Input.GetMouseButtonDown(0) 
                || Input.GetMouseButtonDown(1)
                || Input.GetMouseButtonDown(2))
            {
                return;
            } if(Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJump();
                playerAnimator.SetBool("isWalking",true);
               
            }

           
            
        
        }
    

        MoveCharacter(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")));
     
       
    }

    private void FixedUpdate(){
     
        if(touchStart && thrower.buttonDownControl == false){
            
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            lookDirection = Quaternion.LookRotation(direction);
           
           
            MoveCharacter(direction);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                lookDirection = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));   
            }
               
                 
                  
        }
       
       
         
           
           
    }
        
	

    void MoveCharacter(Vector3 direction)
    {
       
        player.Translate(direction * (speed * Time.deltaTime) );
    }

    public void PlayerJump()
    {
        if (player.position.y < 1 || (player.position.y < 5.8f && player.position.y > 5.7f))
        {
            trail.enabled = false;
            playerRB.AddForce(new Vector3(0,14,0) * 2, ForceMode.Impulse);
            playerAnimator.SetBool("isJump",true);
            playerAnimator.SetBool("isWalking",false);
        }
            
              
    }
}
