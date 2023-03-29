using System;

namespace ninjachimpstudios.utils {

    public static class RandomUtils {

        private static readonly Random RANDOM = new Random();

        private static readonly object SYNC_LOCK = new object();

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

        // a weight of 0 means no weighting to the current value, 1 is complete weight
        public static int WeightedRandom(int currentValue, int minValue, int maxValue, double weight) {
            int range = maxValue - minValue;
            double midpoint = minValue + (range / 2.0);
            double lowerRange = midpoint - minValue;
            double upperRange = maxValue - midpoint;

            double randomValue = NextDouble();

            double deviation = (randomValue * 2.0 - 1.0) * (1.0 - weight);

            int newValue = (int)Math.Round(currentValue + deviation * (deviation < 0 ? lowerRange : upperRange));

            if (newValue < minValue) {
                newValue = minValue;
            } else if (newValue > maxValue) {
                newValue = maxValue;
            }

            return newValue;
        }
        
        // a weight of 0 means no weighting to the current value, 1 is complete weight
        public static double WeightedRandom(double currentValue, double minValue, double maxValue, double weight) {
            double range = maxValue - minValue;
            double midpoint = minValue + (range / 2.0);
            double lowerRange = midpoint - minValue;
            double upperRange = maxValue - midpoint;

            double randomValue = NextDouble();

            double deviation = (randomValue * 2.0 - 1.0) * (1.0 - weight);

            double newValue = Math.Round(currentValue + deviation * (deviation < 0 ? lowerRange : upperRange));

            if (newValue < minValue) {
                newValue = minValue;
            } else if (newValue > maxValue) {
                newValue = maxValue;
            }

            return newValue;
        }

    }

}