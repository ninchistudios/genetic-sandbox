using System;
using System.Collections.Generic;
using ncs.utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace ncs {

    public class SimManager : Singleton<SimManager> {

        [SerializeField] public int framesPerDay = 30;
        [SerializeField] public bool playing = false;

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

                foreach (var organism in Organisms) {
                    organism.Live();
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

    };

}