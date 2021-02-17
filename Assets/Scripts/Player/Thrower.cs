using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thrower : MonoBehaviour
{
    public Image power;
    public float hitForce;
    public bool pointerDown;
    public bool throwEnemy;
    public bool canThrow;
    public Vector3 throwVector;
    public Rigidbody enemyRB;
    public Vector3 enemyPos;
    public Animator playerAnimator;
    public bool buttonDownControl;
    public ParticleSystem angry;
    public TrailRenderer trail;
    public Transform player;
    
 

    private void Start()
    {
         trail.endColor = new Color32(1,1,1,0);
        trail.endWidth = 0.2f;
    }

    void Update()
    {

       
       
        
        if(pointerDown == true)
        {
            power.fillAmount += 0.01f;
            hitForce = power.fillAmount * 10;
        }       

        if(throwEnemy == true && canThrow==true && playerAnimator.GetBool("punchEnd")){
           
            enemyRB.AddForce(new Vector3(throwVector.x,throwVector.y+1.4f,throwVector.z) * hitForce,ForceMode.Impulse);
              
              
            
            power.fillAmount = 0;
            hitForce = 0;
            playerAnimator.SetBool("punchEnd",false);
        }
    }
    public void OnPress()
    {
        pointerDown = true;
        throwEnemy = false;
        playerAnimator.SetBool("onPressA",true);
        playerAnimator.SetBool("isWalking",false);
        playerAnimator.SetBool("isPunch",false);
        buttonDownControl = true;
        angry.Play();
       

    }
   public void OnRelease()
    {
       throwEnemy = true;
       pointerDown = false;
       if(canThrow == false){
           power.fillAmount = 0;
       }   
       playerAnimator.SetBool("onPressA",false);    
       playerAnimator.SetBool("isWalking",false);
       playerAnimator.SetBool("isPunch",true);
       buttonDownControl = false;
       angry.Stop();
        
    }
    
     private void OnTriggerEnter(Collider enemy)
    {
        enemyRB = enemy.gameObject.GetComponentInParent<Rigidbody>();
        enemyPos =  enemy.transform.position;
        throwVector = enemyPos - player.transform.position;
        if(enemy.gameObject.CompareTag("EnemyThrowZone"))
        {
            canThrow = true;
            hitForce = 0;
         
          
        }
        else
        {
            canThrow = false;
        }
    }
    private void OnTriggerStay(Collider enemy)
   {
       enemyRB = enemy.gameObject.GetComponentInParent<Rigidbody>();
        enemyPos =  enemy.transform.position;
        throwVector = enemyPos - player.transform.position;
      

       if(enemy.gameObject.CompareTag("EnemyThrowZone"))
       {
          
           canThrow = true;      
       }
     
   }
   private void OnTriggerExit(Collider enemy)
    {
        if(enemy.gameObject.CompareTag("EnemyThrowZone"))
        {
            canThrow = false;
        }
    }
}
