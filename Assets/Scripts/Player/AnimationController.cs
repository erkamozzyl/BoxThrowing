using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator playerAnimator;
   
   public void JumpAnimationEnd()
   {
        playerAnimator.SetBool("isJump",false);
        GetComponentInChildren<TrailRenderer>().enabled = true;
         
   }
   public void PunchAnimationEnd()
   {
       playerAnimator.SetBool("isPunch",false);
  
     
   }

   public void ThrowControl()
   {
       playerAnimator.SetBool("punchEnd",true);
   }
   

 
}
