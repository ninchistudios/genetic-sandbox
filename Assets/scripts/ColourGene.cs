using UnityEngine;

namespace ncs {

    public class ColourGene : Gene {

        public ColourGene(string descriptor, Color color) : base(descriptor) {
            this.TheColor = color;
        }

        public ColourGene(ColourGene other) : base(other) { }

        private ColourGene() : base() {
            
        }

        public Color TheColor { get; private set; }

        public override Gene DeepCopy() {
            Color deepc = new Color(TheColor.r, TheColor.g, TheColor.b, TheColor.a);
            return new ColourGene(this.Descriptor, deepc);
        }

        public override void DoMutation(double weight) {
            throw new System.NotImplementedException();
        }

        public override void Express() {
            throw new System.NotImplementedException();
        }

    }

}