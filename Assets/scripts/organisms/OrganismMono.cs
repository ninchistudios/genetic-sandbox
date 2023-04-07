using System;
using System.Collections;
using System.Collections.Generic;
using ncs.Genes;
using ncs.utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ncs {

    public class OrganismMono : MonoBehaviour {

        [SerializeField] public string species = "HerbivoreA";
        [SerializeField] public double normalMutationRate = 0.01; // suggested 0.001
        [SerializeField] public double metaMutationRate = 0.001; // suggested 0.00001
        [SerializeField] public double mutationWeight = 0.5; // suggested 0.5
        [SerializeField] public double metaMutationWeight = 0.95; // suggested 0.95
        [SerializeField] public SpriteRenderer bodySprite;
        [SerializeField] public int idealPackSize = 1;
        [SerializeField] public int maxAge = 50;
        public UnityEvent deathEvent = new UnityEvent();
        public UnityEvent birthEvent = new UnityEvent();
        public GeneticOrganism Organism { get; private set; }
        private bool reportedAlive = false;
        private bool reportedDead = false;

        private void OnEnable() {
            List<Gene> genes = new List<Gene>();
            genes.Add(new ColourGene(bodySprite.color));
            genes.Add(new SocialisationGene(idealPackSize));
            Genome genome = new Genome(genes, normalMutationRate, metaMutationRate, mutationWeight, metaMutationWeight);
            Organism = new GeneticOrganism(genome, species, RandomUtils.Next(0, 2) == 0, 0);
        }

        void Update() {
            Organism.Live(this);
            if (!reportedDead && !Organism.IsAlive) {
                reportedDead = true;
                deathEvent.Invoke();
            }

            if (!reportedAlive && Organism.IsAlive) {
                reportedAlive = true;
                birthEvent.Invoke();
            }
        }
        
    }

}