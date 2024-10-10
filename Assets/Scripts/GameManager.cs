using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameState currentGameState;
    private NavMeshSurface navMeshSurface;


    private void Awake() {
        navMeshSurface = FindObjectOfType<NavMeshSurface>();
    }

    private void Start() {
        EnterBuildingMode();
        UIManagerEvents.OnPlayModeButtonClicked += HandlePlayModeButtonClicked;
    }

    private void OnDestroy() {
        UIManagerEvents.OnPlayModeButtonClicked -= HandlePlayModeButtonClicked;
    }   

    private void HandlePlayModeButtonClicked() {
        EnterPlayMode();
    }

    private void EnterBuildingMode() {
        currentGameState = GameState.BuildingMode;
        GameManagerEvents.ChangeGameState(currentGameState);
    }

    private void EnterPlayMode() {
        currentGameState = GameState.PlayMode;
        navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
        GameManagerEvents.ChangeGameState(currentGameState);
    }
}

public enum GameState {
    BuildingMode,
    PlayMode
}