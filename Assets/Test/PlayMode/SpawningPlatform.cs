using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class SpawningPlatformTesting {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SpawningAPlatform() {
            var gameObject = new GameObject();
            var spawner = gameObject.AddComponent<Spawner>();

            yield return null;

            Assert.AreEqual(spawner.spawnedObjects.Count, 1);
        }

        [UnityTest]
        public IEnumerator SpawningPlatformWithSpeed() {
            var gameObject = new GameObject();
            var spawner = gameObject.AddComponent<Spawner>();

            yield return null;

            Assert.AreEqual(spawner.spawnedObjects[0].GetComponent<MovingPlatform>().Speed, 0.02f);
        }
    }
}
