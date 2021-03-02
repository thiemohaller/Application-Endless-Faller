using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests {
    /// <summary>
    ///     I am not sure how I could write more tests without using mocking tools such as NSubstitute...
    ///     One of the key takeaways after trying to test my game is that I should keep it more in mind when programming the game, in order to make it easier to test. 
    ///     These tests all fail because I can't easily mock missing things like Text, this may also be due to my inexperience with testing Unity.
    /// </summary>
    public class LevelManagerTesting {

        [UnityTest]
        public IEnumerator LevelManagerIncrementScoreTest() {
            var levelManager = new GameObject().AddComponent<LevelManager>();
            levelManager.IncrementScore();

            yield return null;

            Assert.AreEqual(levelManager.Score, 1);
        }

        [UnityTest]
        public IEnumerator LevelManagerNewHighScore() {
            var levelManager = new GameObject().AddComponent<LevelManager>();
            levelManager.previousHighScore = 0;
            levelManager.IncrementScore();

            yield return null;

            Assert.AreEqual(levelManager.newHighScore, 1);
        }

        [UnityTest]
        public IEnumerator LevelManagerNotNewHighScore() {
            var levelManager = new GameObject().AddComponent<LevelManager>();
            levelManager.previousHighScore = 4;
            levelManager.IncrementScore();

            yield return null;

            Assert.AreEqual(levelManager.newHighScore, 4);
        }
    }
}
