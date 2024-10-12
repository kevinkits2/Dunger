using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinder : MonoBehaviour {

    private const string IS_MOVING = "IsMoving";

    [SerializeField] private Transform finish;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private NavMeshAgent agent;
    private bool isMoving = false;
    private bool finished = false;


    private void Awake() {
        agent = GetComponent<NavMeshAgent>();

        GameManagerEvents.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDestroy() {
        GameManagerEvents.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState state) {
        if (state == GameState.PlayMode && !finished) {
            agent.destination = finish.position;
            isMoving = true;
        }
    }

    private void Update() {
        if (finished) return;

        FlipSprite();
        DestinationCheck();
        animator.SetBool(IS_MOVING, isMoving);
    }

    private void DestinationCheck() {
        if (Vector3.Distance(transform.position, finish.position) < 0.1f) {
            isMoving = false;
            finished = true;
        }
    }

    private void FlipSprite() {
        if (agent.velocity.x > 0) {
            spriteRenderer.flipX = false;
        }
        else {
            spriteRenderer.flipX = true;
        }
    }
}
