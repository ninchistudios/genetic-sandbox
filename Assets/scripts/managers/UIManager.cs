using System.Collections;
using ncs.utils;
using UnityEngine;
using UnityEngine.UIElements;

namespace ncs {

    public class UIManager : Singleton<UIManager> {

        private VisualTreeAsset _visualTree;
        private UIDocument _uiDocument;

        void Start() {
            _uiDocument = gameObject.GetComponent<UIDocument>();
            StartCoroutine(OneSecondUpdate());
        }

        private IEnumerator OneSecondUpdate() {
            while (true) {
                yield return new WaitForSeconds(1);
            }
        }

    }

}