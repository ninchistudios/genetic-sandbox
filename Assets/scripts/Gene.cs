using System;
using ncs.utils;

namespace ncs {

    public abstract class Gene {

        // following meta properties never change
        public readonly string Descriptor;
        public readonly int Maxvalue;
        public readonly int Minvalue;

        public Gene(int minvalue) {
            Minvalue = minvalue;
        }

        // copy constructor, no logic
        public Gene(Gene other) {

            Descriptor = other.Descriptor;
            Minvalue = other.Minvalue;
            Maxvalue = other.Maxvalue;
            Value = other.Value;
        }

        // following properties change routinely in normal mutations
        public int Value { get; private set; }

        /// <summary>Each gene property has a normal chance to mutate</summary>
        /// <param name="rate">normal mutation rate - double in the range 0.0 - 1.0</param>
        /// ///
        /// <param name="weight">mutation weight - double in the range 0.0 - 1.0</param>
        /// <exception cref="ArgumentOutOfRangeException">If validation of the params fails</exception>
        public void MutateNormally(double rate, double weight) {
            if (rate < 0.0d || rate > 1.0d) throw new ArgumentOutOfRangeException();
            if (weight < 0.0d || weight > 1.0d) throw new ArgumentOutOfRangeException();
            if (RandomUtils.NextDouble() < rate) DoMutation(weight);
        }

        /// <summary>Each gene property will mutate</summary>
        /// <param name="weight">mutation weight - double in the range 0.0 - 1.0</param>
        /// <exception cref="ArgumentOutOfRangeException">If validation of the params fails</exception>
        public void MutateGuaranteed(double weight) {
            if (weight < 0.0d || weight > 1.0d) throw new ArgumentOutOfRangeException();
            DoMutation(weight);
        }

        private void DoMutation(double weight) {
            Value = RandomUtils.WeightedRandom(Value, Minvalue, Maxvalue, weight);
        }

        // TODO how the gene expresses itself
        public abstract void Express();

    }

}