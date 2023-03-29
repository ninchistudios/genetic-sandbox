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
        public void TestGenomeDeepCopiesCorrectly() {
            List<Gene> g = new List<Gene>();
            string testDescriptor = "TestColourGene";
            g.Add(new ColourGene(testDescriptor, Color.gray));
            Genome genome1 = new Genome(g, 0.001d, 0.00001d, 0.5d, 0.95d);
            Genome genome2 = new Genome(genome1);
            Assert.AreNotEqual(genome1, genome2);
            Assert.AreNotEqual(genome1.Genes, genome2.Genes);
            Assert.AreNotEqual(genome1.Genes.Find(a => a.Descriptor.Equals(testDescriptor)),
                genome2.Genes.Find(b => b.Descriptor.Equals(testDescriptor)));
            Assert.AreNotEqual(genome1.Genes[0], genome2.Genes[0]);
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