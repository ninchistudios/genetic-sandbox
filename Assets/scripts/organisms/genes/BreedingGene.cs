using ncs.utils;
using UnityEngine;

namespace ncs.Genes {

    public class BreedingGene : Gene {

        private static readonly string DESCRIPTOR = "BreedingGene";

        protected BreedingGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public BreedingGene(BreedingGene other) : base(other) {
            Descriptor = DESCRIPTOR;
            // TODO implement
        }

        public override Gene DeepCopy() {
            throw new System.NotImplementedException();
        }

        public override void DoMutation(double weight) {
            throw new System.NotImplementedException();
        }

        public override void Express(OrganismMono go) {
            throw new System.NotImplementedException();
        }

    }

}