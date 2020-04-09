using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public GameObject spawnedObject;

    //Time Between
    public float timeBetweenSpawns;

    private float spawnCountdown;
    //Transform
    private Transform tf;
    // Array of locations to spawn to
    public Transform[] spawnLocations;
    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();

        spawnCountdown = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        //If there is there nothing currently spawned
        if (spawnedObject == null)
        {
            spawnCountdown -= Time.deltaTime;
            //Countdown
            if (spawnCountdown <= 0)
            {
                //Using Spawning locations within the range
                int locationId = Random.Range(0, spawnLocations.Length);
                Transform spawnTransform = spawnLocations[locationId];
                //Spawn powerup object
                spawnedObject = Instantiate(objectToSpawn, spawnTransform.position, spawnTransform.rotation) as GameObject;
                //Reset timer for the next powerup after being obtained
                spawnCountdown = timeBetweenSpawns;
            }
        }
    }
}
