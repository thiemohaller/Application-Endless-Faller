using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float timeBetweenSpawns = 3f;
    public int amountToPool = 20;

    private GameObject[] platformPrefabs;
    private float timeToSpawn = .2f; // time until spawning for the first time
    private List<GameObject> spawnedObjects;
    private List<GameObject> taggedForDeletion;

    private void Awake() {
        platformPrefabs = Resources.LoadAll<GameObject>("PlatformPrefabs");               
        spawnedObjects = new List<GameObject>();
        taggedForDeletion = new List<GameObject>();
    }

    private void Update() {
        if (Time.time >= timeToSpawn) {
            SpawnerLogic();
            timeToSpawn = Time.time + timeBetweenSpawns;
        }

        if (taggedForDeletion.Count > amountToPool) {
            taggedForDeletion.Clear();
        }
    }

    internal void Notify(GameObject movingPlatform) {
        spawnedObjects.Remove(movingPlatform);
        taggedForDeletion.Add(movingPlatform);
    }

    void SpawnerLogic() {
        var random = new System.Random();
        var randomInteger = random.Next(0, platformPrefabs.Length);

        var currentPlatform = Instantiate(platformPrefabs[randomInteger], transform);        
        currentPlatform.transform.rotation = Quaternion.identity;

        // In order to create "more" prefabs, rotate platform half the time, using a `coinflip`
        if (random.Next(0, 2) == 0) {
            currentPlatform.transform.RotateAround(currentPlatform.transform.position, transform.right, 180);            
        }
        spawnedObjects.Add(currentPlatform);
    }
}
