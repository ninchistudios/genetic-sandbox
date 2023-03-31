using UnityEngine;

namespace ncs.Genes {

    public class LifecycleGene : Gene {

        private static readonly string DESCRIPTOR = "LifecycleGene";

        protected LifecycleGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public LifecycleGene(LifecycleGene other) : base(other) {
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
            // lifecycle phases:
            // - breedmin / breedmax : ages in days between which breeding is possible and mate-seeking occurs
            // - senescence : age in days at which degradation begins - needs a way to be expressed such as speed, and a daily death chance
            throw new System.NotImplementedException();
        }

    }

}