using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemyCount = 3;
    public GameObject[] activeEnemyCounter;
    private List<GameObject> enemies;
    
    void Awake()
    {
               
       
        

        enemies = new List<GameObject>(enemyCount);

        for(int i = 0; i<enemyCount; i++)
        {
            GameObject prefabInstance = ObjectPoolingManager.Instance.GetEnemy();
            prefabInstance.transform.position = new Vector3(Random.Range(-5,5),1,Random.Range(-5,5));
            //prefabInstance.transform.SetParent(transform);
           // prefabInstance.SetActive(false);
           prefabInstance.GetComponentInChildren<ParticleSystem>().Play();
            enemies.Add(prefabInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        activeEnemyCounter = GameObject.FindGameObjectsWithTag("Enemy");
        if(activeEnemyCounter.Length<3)
        {
            GameObject enemyObject = ObjectPoolingManager.Instance.GetEnemy();
            enemyObject.transform.position = new Vector3(Random.Range(-9,9),1,Random.Range(-9,9));
            enemyObject.GetComponentInChildren<ParticleSystem>().Play();
         
          
        }
    }
}
