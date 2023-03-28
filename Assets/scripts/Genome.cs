using System;
using System.Collections.Generic;
using System.Linq;
using ninjachimpstudios.utils;

namespace ninjachimpstudios {

    public class Genome {

        // copy constructor, no logic
        public Genome(Genome other) {
            this.Genes = other.Genes.ToList(); // deep copies
            this.NormalMutationRate = other.NormalMutationRate;
            this.MetaMutationRate = other.MetaMutationRate;
            this.GuaranteedMutatedGenesRate = other.GuaranteedMutatedGenesRate;
            this.MutationWeight = other.MutationWeight;
            this.MetaMutationWeight = other.MetaMutationWeight;
        }

        public Genome(Genome parent1, Genome parent2) {
            // TODO
        }

        // all Genes associated with the Genome, each mutates normally
        public List<Gene> Genes { get; }

        // following properties govern metagenetics of the genome, and mutate very rarely
        public double NormalMutationRate { get; private set; } // suggested 0.001
        public double MetaMutationRate { get; private set; } // suggested 0.00001
        public double GuaranteedMutatedGenesRate { get; private set; } // suggested 0.2
        public double MutationWeight { get; private set; } // suggested 0.5
        public double MetaMutationWeight { get; private set; } // suggested 0.95

        // the genome itself, and each gene has a chance to mutate according the [Meta]MutationChance
        public void MutateNormally() {
            if (RandomUtils.NextDouble() < MetaMutationRate) MetaMutateGuaranteed();
            foreach (var gene in Genes) {
                gene.MutateNormally(NormalMutationRate, MutationWeight);
            }
        }

        // A number of genes, by the GuaranteedMutatedGenesRate, will mutate
        public void MutateGuaranteed() {
            throw new MutationFailedException();
        }

        // one MetaGenetic property will mutate
        private double MetaMutateGuaranteed() {
            throw new NotImplementedException();
        }

    }

    public class MutationFailedException : Exception { }

}