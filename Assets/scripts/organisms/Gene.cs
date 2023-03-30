using System;
using ncs.utils;

namespace ncs {

    public abstract class Gene {

        // following meta properties never change
        public string Descriptor;

        // copy constructor, no logic
        // should be called and expanded by subclasses
        public Gene(Gene other) { }

        protected Gene() { }

        // returns a deep copy of itself
        public abstract Gene DeepCopy();

        /// <summary>The gene has a normal chance to mutate</summary>
        /// <param name="rate">normal mutation rate - double in the range 0.0 - 1.0</param>
        /// ///
        /// <param name="weight">mutation weight - double in the range 0.0 - 1.0</param>
        /// <exception cref="ArgumentOutOfRangeException">If validation of the params fails</exception>
        public void MutateNormally(double rate, double weight) {
            if (rate < 0.0d || rate > 1.0d) throw new ArgumentOutOfRangeException();
            if (weight < 0.0d || weight > 1.0d) throw new ArgumentOutOfRangeException();
            if (RandomUtils.NextDouble() < rate) DoMutation(weight);
        }

        /// <summary>the gene will definitely mutate</summary>
        /// <param name="weight">mutation weight - double in the range 0.0 - 1.0</param>
        /// <exception cref="ArgumentOutOfRangeException">If validation of the params fails</exception>
        public void MutateGuaranteed(double weight) {
            if (weight < 0.0d || weight > 1.0d) throw new ArgumentOutOfRangeException();
            DoMutation(weight);
        }

        /// <summary>Called when mutation is required, implemented in subclass</summary>
        /// <param name="weight">mutation weight - double in the range 0.0 - 1.0</param>
        public abstract void DoMutation(double weight);

        /// <summary>The implementation of the Gene's behaviour</summary>
        public abstract void Express();

    }

}