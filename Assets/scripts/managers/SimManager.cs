using System;
using System.Collections.Generic;
using ncs.Genes;
using ncs.utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ncs {

    public class SimManager : Singleton<SimManager> {

        [SerializeField] public bool playing = false;
        [SerializeField] public int framesPerDay = 30;
        [SerializeField] public double spawnPositionWeight = 0.5;
        [SerializeField] public GameObject spawnParent;
        [SerializeField] public List<GameObject> herbivorePrefabs;
        [SerializeField] public List<GameObject> carnivorePrefabs;
        [SerializeField] public List<GameObject> environmentPrefabs;
        public int LiveOrganisms { get; private set; } = 0;

        public List<GeneticOrganism> Organisms { get; private set; }

        public int SimDay { get; private set; } = 0;

        public int Generation { get; private set; } = 0;

        //public bool Playing { get; private set; } = false;
        private int frameRoller = 0;

        void Awake() {
            Application.targetFrameRate = -1;
            QualitySettings.vSyncCount = 0;
        }

        public void OnEnable() {
            InitNewSim();
        }

        private void InitNewSim() {
            playing = false;
            Organisms = new List<GeneticOrganism>();
            SimDay = 1;
            Generation = 1;
            frameRoller = 1;
        }

        public void Update() {

            if (playing) {
                frameRoller++;
                if (frameRoller > framesPerDay) {
                    frameRoller = 1;
                    SimDay++;
                }
            }
        }

        public void PlaySim() {
            playing = true;
        }

        public void PauseSim() {
            playing = false;
        }

        public void ResetSim() {
            InitNewSim();
        }

        public void SpawnHerbivores() {
            Spawn(herbivorePrefabs[RandomUtils.Next(0, herbivorePrefabs.Count)]);
        }

        public void SpawnCarnivores() {
            Spawn(carnivorePrefabs[RandomUtils.Next(0, carnivorePrefabs.Count)]);
        }
        
        public void SpawnEnvironment() {
            Spawn(environmentPrefabs[RandomUtils.Next(0, environmentPrefabs.Count)]);
        }

        private void OrganismBorn() {
            LiveOrganisms += 1;
        }

        private void OrganismDied() {
            LiveOrganisms -= 1;
        }

        public void Spawn(GameObject spawn) {
            // the first spawn is random, the remainder are weighted to its position
            // all spawns in a pack will be the same (random) species for now and a random age
            // pack size is governed by the first spawn's socialisation gene (if exists)
            Vector3 pos = RandomUtils.Random2DVector3(Screen.width, Screen.height, 5);
            GameObject spawned = Instantiate(spawn, Camera.main.ScreenToWorldPoint(pos), Quaternion.identity,
                spawnParent.transform);
            OrganismMono spawnedMono = spawned.GetComponent<OrganismMono>(); 
            spawnedMono.birthEvent.AddListener(OrganismBorn);
            spawnedMono.deathEvent.AddListener(OrganismDied);
            spawnedMono.Organism.SetRandomAge(spawnedMono.maxAge);
            int packSize = 1;
            try {
                SocialisationGene sg = (SocialisationGene)spawnedMono.Organism.Genome.Genes
                    .Find(a => a.Descriptor.Equals("SocialisationGene"));
                packSize = sg.IdealPackSize;
            } catch (Exception e) {
                Debug.Log(e);
            }

            for (int i = 0; i < packSize - 1; i++) {
                pos = RandomUtils.RandomWeighted2DVector3(Screen.width, Screen.height, pos, spawnPositionWeight);
                OrganismMono om =
                    Instantiate(spawn, Camera.main.ScreenToWorldPoint(pos), Quaternion.identity, spawnParent.transform)
                        .GetComponent<OrganismMono>();
                om.birthEvent.AddListener(OrganismBorn);
                om.deathEvent.AddListener(OrganismDied);
                om.Organism.SetRandomAge(om.maxAge);
            }

        }

    };

}