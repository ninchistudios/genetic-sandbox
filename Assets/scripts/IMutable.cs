namespace ninjachimpstudios {

    public interface IMutable {

        // each time an IMutable's gene(s) replicate, each has this chance to mutate
        public double NormalMutationRate { get; }
        // each time an IMutable  mutates guaranteed, this rate of genes mutate
        public double GuaranteedMutatedGenesRate { get; }
        
        public IMutable MutateNormally();
        public IMutable MutateGuaranteed();

    }

}