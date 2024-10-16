using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private PlayerControls playerControls;
    private GameState currentGameState;
    private Vector2 cameraMoveVector;


    private void Awake() {
        playerControls = new PlayerControls();
        playerControls.Enable();

        GameManagerEvents.OnGameStateChanged += HandleGameStateChanged;
        InputManagerEvents.OnCameraMovementVectorRequested += HandleCameraMovementVectorRequested;

        playerControls.BuildMode.Select.performed += HandleSelectPerformed;
        playerControls.BuildMode.Deselect.performed += HandleDeselectPerformed;
        playerControls.Game.OnPause.performed += HandlePausePerformed;
    }

    private void OnDestroy() {
        GameManagerEvents.OnGameStateChanged -= HandleGameStateChanged;
        InputManagerEvents.OnCameraMovementVectorRequested -= HandleCameraMovementVectorRequested;
    }

    private Vector2 HandleCameraMovementVectorRequested() {
        return cameraMoveVector;
    }

    private void HandleGameStateChanged(GameState state) {
        state = currentGameState;
    }

    private void HandleDeselectPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (currentGameState != GameState.BuildingMode) return;

        InputManagerEvents.BuildModeDeselectPerformed();
    }

    private void HandleSelectPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (currentGameState != GameState.BuildingMode) return;

        InputManagerEvents.BuildModeSelectPerformed();
    }

    private void HandlePausePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        InputManagerEvents.PausePerformed();
    }

    private void GetCameraMoveVector() {
        cameraMoveVector = playerControls.Game.MovementVector.ReadValue<Vector2>();
    }

    private void Update() {
        GetCameraMoveVector();
    }
}
