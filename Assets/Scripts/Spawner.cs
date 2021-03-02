using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float timeBetweenSpawns = 3f;
    public float platformSpeed = 0.02f;

    private GameObject[] platformPrefabs;
    private float timeToSpawn = 0.02f; // time until spawning for the first time
    private List<GameObject> spawnedObjects;

    private void Awake() {
        platformPrefabs = Resources.LoadAll<GameObject>("PlatformPrefabs");               
        spawnedObjects = new List<GameObject>();
    }

    private void Update() {
        if (Time.time >= timeToSpawn) {
            SpawnerLogic();
            timeToSpawn = Time.time + timeBetweenSpawns;
        }
    }

    void SpawnerLogic() {
        var random = new System.Random();
        var randomInteger = random.Next(0, platformPrefabs.Length);

        var currentPlatform = Instantiate(platformPrefabs[randomInteger], transform);        
        currentPlatform.transform.rotation = Quaternion.identity;
        // By using the line below, we only have to reference a `Spawner` object in the LevelManager 
        currentPlatform.GetComponent<MovingPlatform>().Speed = platformSpeed;

        // In order to create "more" prefabs, rotate platform half the time, using a `coinflip`
        if (random.Next(0, 2) == 0) {
            currentPlatform.transform.RotateAround(currentPlatform.transform.position, transform.right, 180);            
        }
        spawnedObjects.Add(currentPlatform);
    }
}
