using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinder : MonoBehaviour {

    [SerializeField] private Transform finish;
    private NavMeshAgent agent;


    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start() {
        agent.destination = finish.position;
    }
}
