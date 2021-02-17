using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance{get {return instance;}}

    public GameObject enemyPrefab;
    private List<GameObject> enemies;
    
    
    
 private void Awake()
 {
     
      instance = this;
      enemies = new List<GameObject>(3);
      
      //enemyPrefab = (GameObject)Resources.Load("Prefabs/Enemy", typeof(GameObject));
        
 }
    

    public GameObject GetEnemy()
    {
        foreach(GameObject enemy in enemies)
        {
            if(!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        GameObject prefabInstance = Instantiate(enemyPrefab);
        prefabInstance.transform.position = new Vector3(Random.Range(-9,9),Random.Range(-9,9), -11);
        enemies.Add(prefabInstance);          
        return prefabInstance;

    }

}
