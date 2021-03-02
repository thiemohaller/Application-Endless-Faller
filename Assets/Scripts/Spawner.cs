using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [HideInInspector]
    public float timeBetweenSpawns = 3f;
    public float platformSpeed = 0.02f;
    public List<GameObject> spawnedObjects;

    private GameObject[] platformPrefabs;
    private float timeToSpawn = 0.02f; // time until spawning for the first time


    private void Awake() {
        platformPrefabs = Resources.LoadAll<GameObject>("PlatformPrefabs");               
        spawnedObjects = new List<GameObject>();
    }

    private void Update() {
        if (Time.time >= timeToSpawn) {
            SpawnerLogic();
            timeToSpawn = Time.time + timeBetweenSpawns;
            Debug.Log($"Currently spawned: {spawnedObjects.Count}");
        }

        foreach (var platform in spawnedObjects) {
            platform.GetComponent<MovingPlatform>().Speed = platformSpeed;
        }
    }

    void SpawnerLogic() {
        var random = new System.Random();
        var randomInteger = random.Next(0, platformPrefabs.Length);

        var currentPlatform = Instantiate(platformPrefabs[randomInteger], transform);        
        currentPlatform.transform.rotation = Quaternion.identity;
        // By using the line below, we only have to reference a `Spawner` object in the LevelManager 
        // TODO look into adjusting speed on all existing spawned objects -> especially performance
        currentPlatform.GetComponent<MovingPlatform>().Speed = platformSpeed;

        // In order to create "more" prefabs, rotate platform half the time, using a `coinflip`
        if (random.Next(0, 2) == 0) {
            currentPlatform.transform.RotateAround(currentPlatform.transform.position, transform.right, 180);            
        }
        spawnedObjects.Add(currentPlatform);
    }
}
