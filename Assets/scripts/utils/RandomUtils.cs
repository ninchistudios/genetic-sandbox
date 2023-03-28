using System;

namespace ninjachimpstudios.utils {

    public static class RandomUtils {

        private static readonly Random random = new Random();

        private static readonly object syncLock = new object();

        public static int Next(int minValue, int maxValue) {
            lock (syncLock) {
                return random.Next(minValue, maxValue);
            }

        }

    }

}