namespace ncs.Genes {

    public class MovementDriverEatGene : Gene {

        private static readonly string DESCRIPTOR = "MovementDriverEatGene";

        protected MovementDriverEatGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public MovementDriverEatGene(MovementDriverEatGene other) : base(other) {
            Descriptor = DESCRIPTOR;
            // TODO implement
        }
        
        public override Gene DeepCopy() {
            throw new System.NotImplementedException();
        }

        public override void DoMutation(double weight) {
            throw new System.NotImplementedException();
        }

        public override void Express() {
            throw new System.NotImplementedException();
        }

    }

}