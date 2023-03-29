using ncs.utils;
using UnityEngine;

namespace ncs.Genes {

    public class ReproductionGene : Gene {

        private static readonly string DESCRIPTOR = "ReproductionGene";

        protected ReproductionGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public ReproductionGene(ReproductionGene other) : base(other) {
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