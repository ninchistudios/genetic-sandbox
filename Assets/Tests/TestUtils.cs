using System;
using System.Collections;
using System.Collections.Generic;
using ncs.utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ncs {

    public class TestUtils {

        [Test]
        public void TestHighWeightProducesSmallVariance() {
            var varint = 0;
            var vardbl = 0d;
            //Debug.Log("1+3 ints");
            //Debug.Log("random int: " + RandomUtils.Next(0, 100));
            //Debug.Log("Low variance from 50: " + RandomUtils.WeightedRandom(50, 0, 100, 0.99d));
            //Debug.Log("Mid variance from 50: " + RandomUtils.WeightedRandom(50, 0, 100, 0.5d));
            //Debug.Log("High variance from 50: " + RandomUtils.WeightedRandom(50, 0, 100, 0.01d));
            for (int i = 0; i < 1000; i++) {
                varint += Math.Abs(50 - RandomUtils.WeightedRandom(50, 0, 100, 0.99d));
            }
            //Debug.Log("Variance: " + varint);
            Assert.Less(varint, 2000);
            //Debug.Log("1+3 doubles");
            //Debug.Log("random dbl: " + RandomUtils.NextDouble());
            //Debug.Log("Low variance from 0.5: " + RandomUtils.WeightedRandom(0.5d, 0.0d, 1.0d, 0.99d));
            //Debug.Log("Mid variance from 0.5: " + RandomUtils.WeightedRandom(0.5d, 0.0d, 1.0d, 0.5d));
            //Debug.Log("High variance from 0.5: " + RandomUtils.WeightedRandom(0.5d, 0.0d, 1.0d, 0.01d));
            for (int i = 0; i < 1000; i++) {
                vardbl += Math.Abs(0.5d - RandomUtils.WeightedRandom(0.5d, 0.0d, 1.0d, 0.99d));
            }

            //Debug.Log("Variance: " + vardbl);
            Assert.Less(vardbl, 20d);

        }

        [Test]
        public void TestNextForBool() {
            int c = 0;
            for (int i = 0; i < 10000; i++) {
                // RandomUtils.Next(0,2) should return 50% of 0 or 1. 10000 runs should total about 5000 0s. Certainly not 3333.
                c += RandomUtils.Next(0, 2);
            }
            //Debug.Log("c: " + c);
            Assert.Greater(c,4200);
            Assert.Less(c,5800);
        }

    }

}