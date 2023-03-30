using System;
using ncs.utils;

namespace ncs.Genes {

    public class SocialisationGene : Gene {

        private static readonly string DESCRIPTOR = "SocialisationGene";

        public int IdealPackSize { get; private set; }
        
        protected SocialisationGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public SocialisationGene(SocialisationGene other) : base(other) {
            Descriptor = DESCRIPTOR;
            IdealPackSize = other.IdealPackSize;
        }

        public SocialisationGene(int idealPackSize) {
            Descriptor = DESCRIPTOR;
            IdealPackSize = idealPackSize;
        }
        
        public override Gene DeepCopy() {
            return new SocialisationGene(this);
        }

        public override void DoMutation(double weight) {
            // arbitrarily set the bounds of ideal pack size from 1 (loners) to double the current pack size
            IdealPackSize = RandomUtils.WeightedRandom(IdealPackSize,1, IdealPackSize * 2, weight);
        }

        public override void Express(OrganismMono go) {
            // TODO have a radius which you try to keep populated at the IdealPackSize
            // not exactly the same as a pack (which implies cooperation with the same group) but will do for now
        }

    }

}