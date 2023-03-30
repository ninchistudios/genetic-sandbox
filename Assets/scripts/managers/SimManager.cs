using System;
using System.Collections.Generic;
using ncs.utils;
using UnityEngine;

namespace ncs {

    public class SimManager : Singleton<SimManager> {

        public List<GeneticOrganism> Organisms { get; private set; }

        public Int64 SimDay { get; private set; } = 0;
        public int Generation { get; private set; } = 0;
        public bool Playing { get; private set; } = false;

        public void OnEnable() {
            Organisms = new List<GeneticOrganism>();
        }

        public void Update() {

            if (Playing) {
                SimDay++;

                foreach (var organism in Organisms) {
                    organism.Live();
                }

            }
        }

    };

}