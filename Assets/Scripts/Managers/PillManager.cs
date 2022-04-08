using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 5f;
    public Transform[] spawnPoints;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start ()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime+3, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnPillIndex = Random.Range(0, Factory.GetNPrefab());
        Debug.Log("Spawning lagi kawan at: "+spawnPointIndex);
        // Menduplikasi enemy
        Instantiate(Factory.FactoryMethod(spawnPillIndex), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        

    }
}
