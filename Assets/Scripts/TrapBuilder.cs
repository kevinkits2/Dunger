using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TrapBuilder : MonoBehaviour {

    [SerializeField] private LayerMask buildLayerMask;
    [SerializeField] private LayerMask trapLayerMask;
    [SerializeField] private Tilemap tilemap;

    private TrapSO selectedTrap;
    private Vector3 tilePlacementOffset = new Vector3(0.5f, 0.5f, 0f);
    private LayerMask availabilityMask;
    private Vector3Int currentGridPos;
    private bool placementAvailable;


    private void Start() {
        availabilityMask = buildLayerMask | trapLayerMask;

        UIManagerEvents.OnTrapButtonClicked += HandleTrapButtonClicked;
        TrapBuilderEvents.OnPlacementAvailabilityRequested += HandlePlacementAvailabilityRequested;
        InputManagerEvents.OnBuildModeSelectPerformed += HandleBuildModeSelectPerformed;
        InputManagerEvents.OnBuildModeDeselectPerformed += HandleBuildModeDeselectPerformed;
    }

    private void OnDestroy() {
        UIManagerEvents.OnTrapButtonClicked -= HandleTrapButtonClicked;
        TrapBuilderEvents.OnPlacementAvailabilityRequested -= HandlePlacementAvailabilityRequested;
        InputManagerEvents.OnBuildModeSelectPerformed -= HandleBuildModeSelectPerformed;
        InputManagerEvents.OnBuildModeDeselectPerformed -= HandleBuildModeDeselectPerformed;
    }

    private void HandleTrapButtonClicked(TrapSO trapSO) {
        selectedTrap = trapSO;
    }

    private bool HandlePlacementAvailabilityRequested() {
        return placementAvailable;
    }

    private void HandleBuildModeDeselectPerformed() {
        if (selectedTrap == null) return;
        
        selectedTrap = null;
        TrapBuilderEvents.DeselectTrap();
    }

    private void HandleBuildModeSelectPerformed() {
        if (selectedTrap != null && placementAvailable) {
            Instantiate(selectedTrap.trapPrefab, currentGridPos + tilePlacementOffset, Quaternion.identity);
            TrapBuilderEvents.BuildTrap();
        }
    }

    private void Update() {
        GetCurrentGridPos();
    }

    private void FixedUpdate() {
        CheckForAvailability();
    }

    private void GetCurrentGridPos() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentGridPos = tilemap.WorldToCell(mouseWorldPos);
    }

    private void CheckForAvailability() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, buildLayerMask);

        if (!hit) {
            placementAvailable = false;
            return;
        }

        if (hit.transform.TryGetComponent<Trap>(out Trap trap)) {
            placementAvailable = false;
            return;
        }

        placementAvailable = true;
    }
}
