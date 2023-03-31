using ncs.utils;
using UnityEngine;

namespace ncs {

    public class GeneticOrganism : IGeneticOrganism {

        public Genome Genome { get; private set; }
        public string Species { get; private set; }
        public bool IsFemale { get; private set; }
        public int DaysSinceBirth { get; private set; }
        public bool IsAlive { get; private set; }

        public GeneticOrganism(Genome g, string species, bool female, int daysold) {
            Genome = new Genome(g);
            Species = species;
            IsFemale = female;
            DaysSinceBirth = daysold;
            IsAlive = true;
        }

        public GeneticOrganism() { }

        // copy constructor, no logic
        public GeneticOrganism(GeneticOrganism other) {
            DeepCopy(other);
        }

        private void DeepCopy(GeneticOrganism other) {
            Genome = new Genome(other.Genome);
            Species = other.Species;
            IsFemale = other.IsFemale;
            DaysSinceBirth = other.DaysSinceBirth;
            IsAlive = other.IsAlive;
        }

        public void Live(OrganismMono go) {
            if (IsAlive) {
                DaysSinceBirth++;
                foreach (var gene in Genome.Genes) {
                    gene.Express(go);
                }
            }

        }

        public void SetRandomAge(int maxAge) {
            DaysSinceBirth = RandomUtils.Next(0, maxAge);
        }

        // 
        // once bred, the genome mutates normally
        /// <summary>
        /// to breed, must be the same species, must be one male and one female, and both must be breeding age
        /// each gene in the bred genome has an 0.5 chance of being this organism's or the partner's
        /// once bred, the genome mutates normally
        /// </summary>
        /// <param name="partner">GeneticOrganism</param>
        /// <returns>GeneticOrganism</returns>
        public GeneticOrganism BreedWith(GeneticOrganism partner) {
            var offspring = new GeneticOrganism {
                Genome = new Genome(Genome, partner.Genome)
            };
            offspring.Genome.MutateNormally();
            offspring.Species = Species;
            offspring.IsFemale = RandomSex();
            offspring.DaysSinceBirth = 0;
            return offspring;
        }

        // creates an almost exact duplicate, used for initial population seeding
        // only changes are sex (50/50 M/F) and age (0)
        // does not mutate
        public GeneticOrganism ImmaculateGeneticCopy() {
            var clone = new GeneticOrganism(this);
            clone.IsFemale = RandomSex();
            clone.DaysSinceBirth = 0;
            return clone;
        }

        // creates a duplicate which is guaranteed to be mutated in some way
        public GeneticOrganism ImmaculateMutant() {
            GeneticOrganism mutatedClone = ImmaculateGeneticCopy();
            mutatedClone.Genome.MutateGuaranteed();
            return mutatedClone;
        }

        private bool RandomSex() {
            return RandomUtils.Next(0, 2) == 0;
        }

    }

}