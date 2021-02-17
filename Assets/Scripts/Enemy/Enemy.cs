using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  
private void Start()
{
    this.GetComponentInChildren<TrailRenderer>().endColor = new Color32(1,1,1,0);
    this.GetComponentInChildren<TrailRenderer>().endWidth = 0.5f;
}
    void Update()
    {
        
        

      
        if(transform.position.y > -10)
        {
            this.GetComponentInChildren<TrailRenderer>().enabled = true;
        }
        else
        {
             this.GetComponentInChildren<TrailRenderer>().enabled = false;
        }
       
      
    }
    private void OnCollisionEnter(Collision scoreCounter)
        {
            if(scoreCounter.gameObject.CompareTag("ScoreCounter"))
            {
                gameObject.SetActive(false);
            }
        }
}
