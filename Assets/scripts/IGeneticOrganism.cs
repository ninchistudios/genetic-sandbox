namespace ninjachimpstudios {

    public interface IGeneticOrganism {

        public Genome Genome { get; }
        public string Species { get; }
        public bool IsFemale { get; }
        public int DaysSinceBirth { get; }

        public IGeneticOrganism BreedWith(IGeneticOrganism partner);
        public IGeneticOrganism ImmaculateGeneticCopy();
        public IGeneticOrganism ImmaculateMutant();

    }

}