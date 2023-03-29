using System;
using System.Collections.Generic;
using System.Linq;
using ncs.utils;

namespace ncs {

    public class Genome {

        public Genome() { }

        // copy constructor, no logic
        public Genome(Genome other) {
            Genes = other.Genes.ToList(); // deep copies
            NormalMutationRate = other.NormalMutationRate;
            MetaMutationRate = other.MetaMutationRate;
            MutationWeight = other.MutationWeight;
            MetaMutationWeight = other.MetaMutationWeight;
        }

        // breeding constructor
        public Genome(Genome parent1, Genome parent2) {
            // randomise parent1 or parent2's metagenetics
            NormalMutationRate =
                RandomUtils.NextDouble() < 0.5d ? parent1.NormalMutationRate : parent2.NormalMutationRate;
            MetaMutationRate =
                RandomUtils.NextDouble() < 0.5d ? parent1.MetaMutationRate : parent2.NormalMutationRate;
            MutationWeight = RandomUtils.NextDouble() < 0.5d ? parent1.MutationWeight : parent2.MutationWeight;
            MetaMutationWeight =
                RandomUtils.NextDouble() < 0.5d ? parent1.MetaMutationWeight : parent2.MetaMutationWeight;
            // iterate the genes, randomising parent1 or parent2
            // TODO can this be modified to account for dominant or recessive genes?
            Genes = new List<Gene>();
            var parent1TempGenes = parent1.Genes.ToList(); // deep copy
            var parent2TempGenes = parent2.Genes.ToList(); // deep copy
            // potentially some future parents may have extra genes, the longer list should be the one iterated
            var longerList =
                parent2TempGenes.Count > parent1TempGenes.Count ? parent2TempGenes : parent1TempGenes;

            foreach (var gene in longerList)
                if (RandomUtils.NextDouble() < 0.5d) {
                    if (parent1TempGenes.Exists(a => a.Descriptor.Equals(gene.Descriptor)))
                        Genes.Add(parent1TempGenes.Find(a => a.Descriptor.Equals(gene.Descriptor)));
                } else {
                    if (parent2TempGenes.Exists(a => a.Descriptor.Equals(gene.Descriptor)))
                        Genes.Add(parent2TempGenes.Find(b => b.Descriptor.Equals(gene.Descriptor)));
                }
        }

        // all Genes associated with the Genome, each mutates normally
        public List<Gene> Genes { get; }

        // following properties govern metagenetics of the genome, and mutate very rarely
        public double NormalMutationRate { get; private set; } // suggested 0.001
        public double MetaMutationRate { get; private set; } // suggested 0.00001
        public double MutationWeight { get; private set; } // suggested 0.5
        public double MetaMutationWeight { get; private set; } // suggested 0.95

        // the genome itself, and each gene has a chance to mutate according the [Meta]MutationChance
        public void MutateNormally() {
            if (RandomUtils.NextDouble() < MetaMutationRate) MetaMutateGuaranteed();
            foreach (var gene in Genes) gene.MutateNormally(NormalMutationRate, MutationWeight);
        }

        // One random gene is guaranteed to mutate
        public void MutateGuaranteed() {
            var index = RandomUtils.Next(0, Genes.Count);
            Genes[index].MutateGuaranteed(MutationWeight);
            throw new MutationFailedException();
        }

        // one MetaGenetic property will mutate
        public void MetaMutateGuaranteed() {
            // not elegant, but rare
            switch (RandomUtils.NextDouble()) {
                case < 0.25d:
                    NormalMutationRate = RandomUtils.WeightedRandom(NormalMutationRate, 0.0d, 1.0d, MetaMutationWeight);
                    break;
                case < 0.5d:
                    MetaMutationRate = RandomUtils.WeightedRandom(MetaMutationRate, 0.0d, 1.0d, MetaMutationWeight);
                    break;
                case < 0.75d:
                    MutationWeight = RandomUtils.WeightedRandom(MutationWeight, 0.0d, 1.0d, MetaMutationWeight);
                    break;
                default:
                    MetaMutationWeight = RandomUtils.WeightedRandom(MetaMutationWeight, 0.0d, 1.0d, MetaMutationWeight);
                    break;
            }
        }

    }

    public class MutationFailedException : Exception { }

}