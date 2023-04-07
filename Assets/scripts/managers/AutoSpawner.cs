using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ncs {

    public class AutoSpawner : MonoBehaviour {

        [SerializeField] public int minimumHerbivores;
        [SerializeField] public int minimumCarnivores;
        [SerializeField] public int minimumEnvironmentals;

        private SimManager sm;
        private int lastDailies = 0;

        void Start() {
            sm = gameObject.GetComponentInParent<SimManager>();
            if (sm == null || sm.GetType() != typeof(SimManager)) {
                throw new Exception("Parent SimManager not initialised");
            }
        }

        void Update() {

            // only do expensive tests and actions once per day
            if (sm.SimDay > lastDailies) {
                DoDailies();
                lastDailies = sm.SimDay;
            }
        }

        private void DoDailies() {

            if (sm.LiveEnvironment < minimumEnvironmentals) {
                sm.SpawnEnvironment();
            }

            if (sm.LiveHerbivores < minimumHerbivores) {
                sm.SpawnHerbivores();
            }

            if (sm.LiveCarnivores < minimumCarnivores) {
                sm.SpawnCarnivores();
            }
        }

    }

}