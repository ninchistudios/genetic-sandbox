using System.Collections;
using System.Collections.Generic;
using ncs.Genes;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ncs {

    [TestFixture]
    public class TestBreeding {

        private GeneticOrganism go1;
        private GeneticOrganism go2;
        private Genome genome;
        private List<Gene> genes;
        private string testDescriptor;
        private string testSpecies;

        [SetUp]
        public void Init() {
            testDescriptor = "ColourGene";
            testSpecies = "TestSpecies";
            ColourGene cg = new ColourGene(Color.gray);
            genes = new List<Gene>();
            genes.Add(cg);
            genome = new Genome(genes, 0.1, 0.001, 0.5, 0.95);
            go1 = new GeneticOrganism(genome, testSpecies, true, 0);
        }

        [Test]
        public void TestOrganismDeepCopyWorksAsExpected() {
            go2 = new GeneticOrganism(go1);
            Assert.AreNotEqual(go1, go2);
            Assert.AreNotEqual(go1.Genome, go2.Genome);
            Assert.AreNotEqual(go1.Genome.Genes.Find(a => a.Descriptor.Equals(testDescriptor)),
                go2.Genome.Genes.Find(b => b.Descriptor.Equals(testDescriptor)));
            ColourGene cg1 = (ColourGene)go1.Genome.Genes.Find(c => c.Descriptor.Equals(testDescriptor));
            ColourGene cg2 = (ColourGene)go2.Genome.Genes.Find(d => d.Descriptor.Equals(testDescriptor));
            Assert.AreNotSame(cg1.TheColor,cg2.TheColor);
            Assert.True(cg1.TheColor.ToString().Equals(cg2.TheColor.ToString()));
        }

        [Test]
        public void TestImmaculateMutantIsVaried() {
            go2 = go1.ImmaculateMutant();
            ColourGene cg1 = (ColourGene)go1.Genome.Genes.Find(a => a.Descriptor.Equals(testDescriptor));
            ColourGene cg2 = (ColourGene)go2.Genome.Genes.Find(b => b.Descriptor.Equals(testDescriptor));
            Assert.AreNotEqual(cg1, cg2);
            Assert.False(cg1.TheColor.ToString().Equals(cg2.TheColor.ToString()));
        }

    }

}