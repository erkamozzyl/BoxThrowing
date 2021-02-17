using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
public int score;
  private void OnCollisionEnter(Collision enemy)
      {
          if(enemy.gameObject.CompareTag("Enemy"))
          {
              score+=1;
          }
      }
  
}
