using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinder : MonoBehaviour {

    [SerializeField] private Transform finish;
    private NavMeshAgent agent;


    private void Awake() {
        agent = GetComponent<NavMeshAgent>();

        GameManagerEvents.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDestroy() {
        GameManagerEvents.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState state) {
        if (state == GameState.PlayMode) {
            agent.destination = finish.position;
        }
    }
}
