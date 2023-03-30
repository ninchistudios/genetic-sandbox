using System;
using System.Collections;
using ncs.utils;
using UnityEngine;
using UnityEngine.UIElements;

namespace ncs {

    public class UIManager : Singleton<UIManager> {

        private UIDocument uiDocument;

        private void OnEnable() {
            uiDocument = gameObject.GetComponent<UIDocument>();
            Button burgerButton = uiDocument.rootVisualElement.Q<Button>("BurgerButton");
            burgerButton.clicked += ShowMenu;
        }

        public void Update() {
            
        }

        void Start() {
            StartCoroutine(OneSecondUpdate());
        }

        private void ShowMenu() {
            
        }

        private void HideMenu() {
            
        }

        private IEnumerator OneSecondUpdate() {
            while (true) {
                yield return new WaitForSeconds(1);
            }
        }

    }

}