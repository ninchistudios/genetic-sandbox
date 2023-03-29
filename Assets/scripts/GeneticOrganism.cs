using ncs.utils;

namespace ncs {

    public class GeneticOrganism : IGeneticOrganism {

        public GeneticOrganism() { }

        // copy constructor, no logic
        public GeneticOrganism(GeneticOrganism other) {
            Genome = new Genome(other.Genome);
            Species = other.Species;
            IsFemale = other.IsFemale;
            DaysSinceBirth = other.DaysSinceBirth;
        }

        public Genome Genome { get; private set; }
        public string Species { get; private set; }
        public bool IsFemale { get; private set; }
        public int DaysSinceBirth { get; private set; }

        // to breed, must be the same species, must be one male and one female, and both must be breeding age
        // each gene in the bred genome has an 0.5 chance of being this organism's or the partner's
        // once bred, the genome mutates normally
        public IGeneticOrganism BreedWith(IGeneticOrganism partner) {
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
        public IGeneticOrganism ImmaculateGeneticCopy() {
            var clone = new GeneticOrganism(this);
            clone.IsFemale = RandomSex();
            clone.DaysSinceBirth = 0;
            return clone;
        }

        // creates a duplicate which is guaranteed to be mutated in some way
        public IGeneticOrganism ImmaculateMutant() {
            IGeneticOrganism mutatedClone = (GeneticOrganism)ImmaculateGeneticCopy();
            mutatedClone.Genome.MutateGuaranteed();
            return mutatedClone;
        }

        private bool RandomSex() {
            return RandomUtils.Next(0, 2) == 0;
        }

    }

}