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
        [SerializeField] public GameObject herbivoreParent;
        [SerializeField] public GameObject carnivoreParent;
        [SerializeField] public GameObject envParent;
        [SerializeField] public List<GameObject> herbivorePrefabs;
        [SerializeField] public List<GameObject> carnivorePrefabs;
        [SerializeField] public List<GameObject> environmentPrefabs;
        public int LiveHerbivores { get; private set; } = 0;
        public int LiveCarnivores { get; private set; } = 0;
        public int LiveEnvironment { get; private set; } = 0;

        public List<GeneticOrganism> Organisms { get; private set; }

        public int SimDay { get; private set; } = 0;

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
            SimDay = 0;
            frameRoller = 0;
            // TODO delete all children of environment and organisms
        }

        public void Update() {

            if (playing) {
                frameRoller++;
                if (frameRoller > framesPerDay) {
                    OneSimDayUpdate();
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
            Spawn(GeneticOrganism.SpawnType.Herbivore, herbivorePrefabs[RandomUtils.Next(0, herbivorePrefabs.Count)]);
        }

        public void SpawnCarnivores() {
            Spawn(GeneticOrganism.SpawnType.Carnivore, carnivorePrefabs[RandomUtils.Next(0, carnivorePrefabs.Count)]);
        }

        public void SpawnEnvironment() {
            Spawn(GeneticOrganism.SpawnType.Environment, environmentPrefabs[RandomUtils.Next(0, environmentPrefabs.Count)]);
        }

        private void HerbivoreBorn() {
            LiveHerbivores += 1;
        }

        private void HerbivoreDied() {
            LiveHerbivores -= 1;
        }

        private void CarnivoreBorn() {
            LiveCarnivores += 1;
        }

        private void CarnivoreDied() {
            LiveCarnivores -= 1;
        }

        private void EnvBorn() {
            LiveEnvironment += 1;
        }

        private void EnvDied() {
            LiveEnvironment -= 1;
        }

        public void Spawn(GeneticOrganism.SpawnType st, GameObject spawn) {
            // the first spawn is random, the remainder are weighted to its position
            // all spawns in a pack will be the same (random) species for now and a random age
            // pack size is governed by the first spawn's socialisation gene (if exists)
            Vector3 pos = RandomUtils.Random2DVector3(Screen.width, Screen.height, 5);
            Transform t;

            if (st == GeneticOrganism.SpawnType.Carnivore) {
                t = carnivoreParent.transform;
            } else if (st == GeneticOrganism.SpawnType.Herbivore) {
                t = herbivoreParent.transform;
            } else if (st == GeneticOrganism.SpawnType.Environment) {
                t = envParent.transform;
            } else {
                t = gameObject.transform;
            }

            GameObject spawned = Instantiate(spawn, Camera.main.ScreenToWorldPoint(pos), Quaternion.identity,
                t);
            OrganismMono spawnedMono = spawned.GetComponent<OrganismMono>();
            AddLifecycleListeners(st, spawnedMono);

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
                    Instantiate(spawn, Camera.main.ScreenToWorldPoint(pos), Quaternion.identity, t)
                        .GetComponent<OrganismMono>();
                AddLifecycleListeners(st, om);
                om.Organism.SetRandomAge(om.maxAge);
            }

        }

        private void AddLifecycleListeners(GeneticOrganism.SpawnType st, OrganismMono mono) {
            switch (st) {
                case GeneticOrganism.SpawnType.Carnivore:
                    mono.birthEvent.AddListener(CarnivoreBorn);
                    mono.deathEvent.AddListener(CarnivoreDied);
                    break;
                case GeneticOrganism.SpawnType.Herbivore:
                    mono.birthEvent.AddListener(HerbivoreBorn);
                    mono.deathEvent.AddListener(HerbivoreDied);
                    break;
                case GeneticOrganism.SpawnType.Environment:
                    mono.birthEvent.AddListener(EnvBorn);
                    mono.deathEvent.AddListener(EnvDied);
                    break;
                default:
                    throw new Exception("Unexpected Spawn Type");
                    break;
            }
            
        }

        private void OneSimDayUpdate() {
            frameRoller = 1;
            SimDay++;
            // TODO refresh slower indexes
        }

    }

}