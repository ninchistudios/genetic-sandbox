using UnityEngine;

namespace ncs.Genes {

    public class MovementExecutorGene : Gene {

        private static readonly string DESCRIPTOR = "MovementExecutorGene";

        protected MovementExecutorGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public MovementExecutorGene(MovementExecutorGene other) : base(other) {
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