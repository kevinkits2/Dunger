using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapButtonUI : MonoBehaviour {

    [SerializeField] private TrapSO trapSO;

    private Button button;
    private Image image;


    private void Awake() {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        button.onClick.AddListener(() => {
            UIManagerEvents.TrapButtonClicked(trapSO);
        });

        image.sprite = trapSO.trapUISprite;
    }
}
