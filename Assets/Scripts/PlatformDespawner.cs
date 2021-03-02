using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDespawner : MonoBehaviour {
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Platform")) {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
