# Genetic Sandbox

A Unity playground for testing genetic algorithms.

Combines both learned and optimised behaviour and genetic selection.

Genes govern characteristics of an organism which are not altered during a single organism's lifecycle.
New genes can be introduced (in code) as part of introducing major mutations to the simulation.
Variations in the genes (random & combinatorial) can be introduced during reproduction.

* Breeding - does the organism breed asexually or sexually - incorporates the organism's sex if relevant
* Colour - the body colour and the ability to alter colour
* Metabolism - ability to digest vegetable and/or animal energy, idle energy cost per mass unit, energy cost per unit travelled, growth
* Size - physical size based on genes, maturity and metabolism
* Locomotion - movement at speed related to genes, maturity, metabolism and behaviour motivators
* Awareness - ability to sense light, food and other organisms and distinguish predators, neutrals or prey
* Lifecycle - maturity, ageing and senescence

Metagenetics governs the settings of the simulation:
* mutation likelihood and variance of genes
* mutation likelihood and variance of metagenetic factors

Brain is a special class of Gene powered by a neural network. it evolves during an organism's life, and is passed on during reproduction (a proxy for imprinting, 
to cut complexity and the number of generations needed). In this way, behaviours that result in sustainable reproduction will be rewarded with continued existence. 
A specific reward structure and backpropagation is not needed - the fittest combinations of genes and behaviours survive.

Genes can contribute input or output nodes to the Behaviour network. e.g.

Awareness contributes the following input nodes:
* bearing & distance to, and size (a proxy for threat) and colour of (number?) nearest detected [food|pack member|predator|potential mate|world boundary]
* bearing & distance to nearest detected world boundary
* bearing and light level of brightest light
* bearing and light level of dimmest light
* Current facing

Locomotion contributes the following output nodes:
* Desired facing direction
* Desired movement urgency (% of max speed)

When an organism is spawned, its genome is randomised from all available genes in the simulation. The input and output nodes of all the genes are tallied, and a random
NN creation heuristic is used to design its brain. This will, over time, also select for the most successful brain architecture. e.g:

* heuristic 1: 1 hidden layer, size=geometric mean of i and o
* heuristic 2: 2 hidden layers, both 1/3 * i
* heuristic 3: 2 hidden layers, 2/3 and 1/3 * i respectively



## Example Frame

TODO 

