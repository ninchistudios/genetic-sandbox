namespace ncs.neuralnetwork {

    public class NeuralLayer {

        public float[,] WeightsArray;
        public float[] BiasesArray;
        public float[] NodeArray;

        private readonly int nNodes;
        private readonly int nInputs;

        public NeuralLayer(int inputs, int nodes) {
            nInputs = inputs;
            nNodes = nodes;
            WeightsArray = new float[nNodes, nInputs];
            BiasesArray = new float[nNodes];
            NodeArray = new float[nNodes];

        }

        public void Forward(float[] inputsArray) {
            for (int i = 0; i < nNodes; i++) {
                for (int j = 0; j < nInputs; j++) {
                    NodeArray[i] += WeightsArray[i, j] * inputsArray[j];
                }

                NodeArray[i] += BiasesArray[i];
            }
        }

        public void Activation() {
            for (int i = 0; i < nNodes; i++) {
                if (NodeArray[i] < 0) NodeArray[i] = 0;
            }
        }

    }

}