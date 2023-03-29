using UnityEngine;

namespace ncs {

    public class ColourGene : Gene {

        public ColourGene(string descriptor, Color color) : base(descriptor) {
            this.color = color;
        }

        public ColourGene(ColourGene other) : base(other) {
            
        }

        public Color color { get; private set; }
        
        public override void DoMutation(double weight) {
            throw new System.NotImplementedException();
        }

        public override void Express() {
            throw new System.NotImplementedException();
        }

    }

}