using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
   public GameObject player;
   void FixedUpdate()
    {
        var position = player.transform.position; 
        transform.position = new Vector3(position.x, position.y + 52, position.z - 18);
        
        
     
       
    }
}
