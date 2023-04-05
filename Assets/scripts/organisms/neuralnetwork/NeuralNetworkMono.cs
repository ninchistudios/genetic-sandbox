using System;
using UnityEditor;
using UnityEngine;

namespace ncs.neuralnetwork {

    public class NeuralNetworkMono : MonoBehaviour {

        public NeuralLayer[] Layers;
        [SerializeField] public int[] networkShape = { 2, 4, 4, 2 };

        public void Awake() {
            Layers = new NeuralLayer[networkShape.Length - 1];
            for (int i = 0; i < Layers.Length; i++) {
                Layers[i] = new NeuralLayer(networkShape[i], networkShape[i + 1]);
            }
        }

        public float[] Brain(float[] inputs) {
            for (int i = 0; i < Layers.Length; i++) {
                if (i == 0) {
                    // first hidden layer driven by inputs 
                    Layers[i].Forward(inputs);
                    Layers[i].Activation();
                } else if (i == Layers.Length - 1) {
                    // output layer, no activation
                    Layers[i].Forward(Layers[i - 1].NodeArray);
                } else {
                    // other hidden layers
                    Layers[i].Forward(Layers[i - 1].NodeArray);
                    Layers[i].Activation();
                }
            }

            return Layers[^1].NodeArray;
        }

    }

}