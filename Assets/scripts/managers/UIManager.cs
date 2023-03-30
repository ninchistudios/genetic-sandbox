using System;
using System.Collections;
using ncs.utils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

namespace ncs {

    public class UIManager : Singleton<UIManager> {

        [SerializeField] public SimManager simManager;
        private UIDocument uiDocument;
        private Label currentDayData;
        private Label framesPerDayData;

        private void OnEnable() {
            uiDocument = gameObject.GetComponent<UIDocument>();
            Button burgerButton = uiDocument.rootVisualElement.Q<Button>("BurgerButton");
            burgerButton.clicked += BurgerClicked;
            Button playButton = uiDocument.rootVisualElement.Q<Button>("PlayButton");
            playButton.clicked += PlayClicked;
            Button pauseButton = uiDocument.rootVisualElement.Q<Button>("PauseButton");
            pauseButton.clicked += PauseClicked;
            Button resetButton = uiDocument.rootVisualElement.Q<Button>("ResetButton");
            resetButton.clicked += ResetClicked;
            currentDayData = uiDocument.rootVisualElement.Q<Label>("CurrentDayData");
            framesPerDayData = uiDocument.rootVisualElement.Q<Label>("FramesPerDayData");
        }

        public void Update() {
            currentDayData.text = simManager.SimDay.ToString();
        }

        void Start() {
            StartCoroutine(OneSecondUpdate());
        }

        private void BurgerClicked() {
            
        }
        
        private void PlayClicked() {
            simManager.PlaySim();
        }
        
        private void PauseClicked() {
            simManager.PauseSim();
        }
        private void ResetClicked() {
            simManager.ResetSim();
        }

        private IEnumerator OneSecondUpdate() {
            framesPerDayData.text = simManager.framesPerDay.ToString();
            while (true) {
                yield return new WaitForSeconds(1);
            }
        }

    }

}