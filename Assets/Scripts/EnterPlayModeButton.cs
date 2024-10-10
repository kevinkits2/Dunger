using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPlayModeButton : MonoBehaviour {

    private Button button;


    private void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            UIManagerEvents.EnterPlayMode();
        });
    }
}
