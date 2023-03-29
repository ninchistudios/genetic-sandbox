using ncs.utils;
using UnityEngine;

namespace ncs.Genes {

    public class ColourGene : Gene {

        private static readonly string DESCRIPTOR = "ColourGene";
        public Color TheColor { get; private set; }

        protected ColourGene() : base() {
            Descriptor = DESCRIPTOR;
        }

        public ColourGene(ColourGene other) : base(other) {
            Descriptor = DESCRIPTOR;
            // new random ColourGene is a random colour at full opacity
            this.TheColor = new Color(RandomUtils.NextFloat(),RandomUtils.NextFloat(),RandomUtils.NextFloat(),1.0f);
        }

        public ColourGene(Color color) : base() {
            Descriptor = DESCRIPTOR;
            this.TheColor = color;
        }

        public override Gene DeepCopy() {
            Color deepc = new Color(TheColor.r, TheColor.g, TheColor.b, TheColor.a);
            return new ColourGene(deepc);
        }

        public override void DoMutation(double weight) {
            float newr = (float)RandomUtils.WeightedRandom(TheColor.r, 0.0, 1.0, weight);
            float newg = (float)RandomUtils.WeightedRandom(TheColor.g, 0.0, 1.0, weight);
            float newb = (float)RandomUtils.WeightedRandom(TheColor.b, 0.0, 1.0, weight);
            float newa = (float)RandomUtils.WeightedRandom(TheColor.a, 0.0, 1.0, weight);
            TheColor = new Color(newr, newg, newb, newa);
        }

        public override void Express() {
            // colour doesn't have a behaviour expression, it's just a property
            // TODO colour could influence a desire to seek out similar coloured terrain as camouflage?
        }

    }

}
