namespace ncs.Genes {

    public class EatingGene : Gene {

        private static readonly string DESCRIPTOR = "EatingGene";

        protected EatingGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public EatingGene(EatingGene other) : base(other) {
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