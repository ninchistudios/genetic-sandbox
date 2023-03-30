namespace ncs {

    public interface IGeneticOrganism {

        public Genome Genome { get; }
        public string Species { get; }
        public bool IsFemale { get; }
        public int DaysSinceBirth { get; }

        public GeneticOrganism BreedWith(GeneticOrganism partner);
        public GeneticOrganism ImmaculateGeneticCopy();
        public GeneticOrganism ImmaculateMutant();

    }

}