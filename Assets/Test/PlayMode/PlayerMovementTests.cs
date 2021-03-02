using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class PlayerMovementTests {
        [Test]
        public void LaterMovementTest() {
            var movement = new Movement(1);
            Assert.AreEqual(1, movement.Calculate(1, 1).x, 0.1f);
        }
    }
}
