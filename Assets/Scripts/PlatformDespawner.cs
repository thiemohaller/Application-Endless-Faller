using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDespawner : MonoBehaviour {
    public Spawner spawner;

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Platform")) {
            var platform = other.gameObject.transform.parent.gameObject;
            spawner.GetComponent<Spawner>().spawnedObjects.Remove(platform);
            Destroy(platform);
        }
    }
}
