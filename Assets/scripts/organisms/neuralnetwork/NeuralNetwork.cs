using System;
using UnityEngine;

namespace ncs.neuralnetwork {

    public class NeuralNetwork : MonoBehaviour {

        public Layer Input;
        public Layer Hidden1;
        public Layer Hidden2;
        public Layer Output;
        
        public class Layer {

            public float[,] WeightsArray;
            public float[] BiasesArray;
            public float[] NodeArray;

            private readonly int nNodes;
            private readonly int nInputs;

            public Layer(int inputs, int nodes) {
                nInputs = inputs;
                nNodes = nodes;
                WeightsArray = new float[nNodes, nInputs];
                BiasesArray = new float[nNodes];
                NodeArray = new float[nNodes];

            }

        }

        public void Awake() {
            
        }

    }

}