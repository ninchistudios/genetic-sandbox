using System;
using System.Collections.Generic;
using ncs.utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace ncs {

    public class SimManager : Singleton<SimManager> {

        [SerializeField] public bool playing = false;
        [SerializeField] public int framesPerDay = 30;
        [SerializeField] public int spawnCount = 1;
        [SerializeField] public double spawnPositionWeight = 0.5;
        [SerializeField] public GameObject spawnParent;
        [SerializeField] public List<GameObject> spawnPrefabs;

        public List<GeneticOrganism> Organisms { get; private set; }

        public int SimDay { get; private set; } = 0;

        public int Generation { get; private set; } = 0;

        //public bool Playing { get; private set; } = false;
        private int frameRoller = 0;

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

        public void Spawn() {
            // the first spawn is random, the remainder are weighted to its position
            Vector3 pos = RandomUtils.Random2DVector3(Screen.width, Screen.height, 5);
            for (int i = 0; i < spawnCount; i++) {
                Instantiate(spawnPrefabs[RandomUtils.Next(0, spawnPrefabs.Count)], Camera.main.ScreenToWorldPoint(pos),Quaternion.identity,spawnParent.transform);
                pos = RandomUtils.RandomWeighted2DVector3(Screen.width, Screen.height, pos, spawnPositionWeight);
            }
        }

    };

}