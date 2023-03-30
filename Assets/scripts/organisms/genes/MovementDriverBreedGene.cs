using UnityEngine;

namespace ncs.Genes {

    public class MovementDriverBreedGene : Gene {

        private static readonly string DESCRIPTOR = "MovementDriverBreedGene";

        protected MovementDriverBreedGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public MovementDriverBreedGene(MovementDriverBreedGene other) : base(other) {
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