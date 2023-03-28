using System;
using System.Collections.Generic;
using System.Linq;

namespace ninjachimpstudios {

    public class Genome : IMutable {

        // copy constructor, no logic
        public Genome(Genome other) {
            this.Genes = other.Genes.ToList(); // deep copies
            this.NormalMutationRate = other.NormalMutationRate;
            this.GuaranteedMutatedGenesRate = other.GuaranteedMutatedGenesRate;
        }

        public Genome(Genome parent1, Genome parent2) { }

        public List<Gene> Genes { get; }
        public double NormalMutationRate { get; }
        public double GuaranteedMutatedGenesRate { get; }

        // each gene has a chance to mutate according the MutationChance
        public IMutable MutateNormally() {
            throw new System.NotImplementedException();
        }

        // A number of genes, by the GuaranteedMutatedGenesRate, will mutate
        public IMutable MutateGuaranteed() {
            throw new System.NotImplementedException();
        }

    }

}