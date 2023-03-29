using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ncs {

    public class NewTestScript {

        private Genome G;

        // A Test behaves as an ordinary method
        [Test]
        public void TestGenomeReplicatesCorrectly() {
            Genome G = new Genome();
            //G.MutationWeight = 0.5d;
            
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses() {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

    }

}