using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class player_movement
    {
        [Test]
        public void player_movementSimplePasses()
        {
        }

      
        [UnityTest]
        public IEnumerator moveCharacter_Move()
        {
            GameObject go = new GameObject("Player");
            MoveCharacter moveChar = go.AddComponent<MoveCharacter>();

           
            yield return null;
        }
    }
}
