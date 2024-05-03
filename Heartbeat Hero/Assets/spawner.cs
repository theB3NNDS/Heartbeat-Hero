using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    float nextSpawnTime;

    public GameObject[] enemy;

    public Transform[] spawnpoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime){
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomSpawnPoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
            Instantiate(enemy[UnityEngine.Random.Range(0, enemy.Length)], randomSpawnPoint.position, Quaternion.identity);
        }
    }
}
