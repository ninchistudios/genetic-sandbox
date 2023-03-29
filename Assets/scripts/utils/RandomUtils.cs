using System;

namespace ncs.utils {

    public static class RandomUtils {

        private static readonly Random RANDOM = new();

        private static readonly object SYNC_LOCK = new();

        public static int Next(int minValue, int maxValue) {
            lock (SYNC_LOCK) {
                return RANDOM.Next(minValue, maxValue);
            }

        }

        // 0.0 to 1.0
        public static double NextDouble() {
            lock (SYNC_LOCK) {
                return RANDOM.NextDouble();
            }
        }

        public static float NextFloat() {
            lock (SYNC_LOCK) {
                return (float)RANDOM.NextDouble();
            }
        }

        // a weight of 0 means no weighting to the current value, 1 is complete weight
        public static int WeightedRandom(int currentValue, int minValue, int maxValue, double weight) {
            var range = maxValue - minValue;
            var midpoint = minValue + range / 2.0;
            var lowerRange = midpoint - minValue;
            var upperRange = maxValue - midpoint;

            var randomValue = NextDouble();

            var deviation = (randomValue * 2.0 - 1.0) * (1.0 - weight);

            var newValue = (int)Math.Round(currentValue + deviation * (deviation < 0 ? lowerRange : upperRange));

            if (newValue < minValue)
                newValue = minValue;
            else if (newValue > maxValue) newValue = maxValue;

            return newValue;
        }

        // a weight of 0 means no weighting to the current value, 1 is complete weight
        public static double WeightedRandom(double currentValue, double minValue, double maxValue, double weight) {
            var range = maxValue - minValue;
            var midpoint = minValue + range / 2.0;
            var lowerRange = midpoint - minValue;
            var upperRange = maxValue - midpoint;

            var randomValue = NextDouble();

            var deviation = (randomValue * 2.0 - 1.0) * (1.0 - weight);

            var newValue = currentValue + deviation * (deviation < 0 ? lowerRange : upperRange);

            if (newValue < minValue)
                newValue = minValue;
            else if (newValue > maxValue) newValue = maxValue;

            return newValue;
        }
        
    }

}