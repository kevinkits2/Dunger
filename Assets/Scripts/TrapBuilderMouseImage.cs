using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TrapBuilderMouseImage : MonoBehaviour {

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Color unavailablePlacementColor;

    private SpriteRenderer spriteRenderer;
    private TrapSO currenTrap;
    private Vector3 tilePlacementOffset = new Vector3(0.5f, 0.5f, 0f);


    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void Start() {
        UIManagerEvents.OnTrapButtonClicked += HandleTrapButtonClicked;
        TrapBuilderEvents.OnTrapBuilt += HandleTrapBuilt;
        TrapBuilderEvents.OnTrapDeselected += HandleTrapDeselected;
    }

    private void OnDestroy() {
        UIManagerEvents.OnTrapButtonClicked -= HandleTrapButtonClicked;
        TrapBuilderEvents.OnTrapBuilt -= HandleTrapBuilt;
        TrapBuilderEvents.OnTrapDeselected -= HandleTrapDeselected;
    }

    private void HandleTrapButtonClicked(TrapSO trapSO) {
        currenTrap = trapSO;
        spriteRenderer.sprite = currenTrap.trapMouseImage;
        spriteRenderer.enabled = true;
    }

    private void HandleTrapBuilt() {
        currenTrap = null;
        spriteRenderer.enabled = false;
    }

    private void HandleTrapDeselected() {
        currenTrap = null;
        spriteRenderer.enabled = false;
    }

    private void Update() {
        if (currenTrap == null) return;

        if (TrapBuilderEvents.RequestPlacementAvailability()) {
            spriteRenderer.color = Color.white;
        }
        else {
            spriteRenderer.color = new Color(unavailablePlacementColor.r, unavailablePlacementColor.g, unavailablePlacementColor.b);
        }


        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = tilemap.WorldToCell(mouseWorldPos);

        transform.position = gridPos + tilePlacementOffset;
    }
}
