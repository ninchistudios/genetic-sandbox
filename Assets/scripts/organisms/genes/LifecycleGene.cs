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

        // Update is called every frame
        // 30 frames to a day - configured
        public override void Express(OrganismMono go) {
            throw new System.NotImplementedException();
        }

    }

}