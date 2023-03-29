using ncs.utils;
using UnityEngine;

namespace ncs {

    public class ColourGene : Gene {

        public ColourGene(string descriptor, Color color) : base(descriptor) {
            this.TheColor = color;
        }

        public ColourGene(ColourGene other) : base(other) { }

        private ColourGene() : base() { }

        public Color TheColor { get; private set; }

        public override Gene DeepCopy() {
            Color deepc = new Color(TheColor.r, TheColor.g, TheColor.b, TheColor.a);
            return new ColourGene(this.Descriptor, deepc);
        }

        public override void DoMutation(double weight) {
            float newr = (float)RandomUtils.WeightedRandom(TheColor.r, 0.0, 1.0, weight);
            float newg = (float)RandomUtils.WeightedRandom(TheColor.g, 0.0, 1.0, weight);
            float newb = (float)RandomUtils.WeightedRandom(TheColor.b, 0.0, 1.0, weight);
            float newa = (float)RandomUtils.WeightedRandom(TheColor.a, 0.0, 1.0, weight);
            TheColor = new Color(newr, newg, newb, newa);
        }

        public override void Express() {
            throw new System.NotImplementedException();
        }

    }

}