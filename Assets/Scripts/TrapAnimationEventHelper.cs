using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimationEventHelper : MonoBehaviour {

    private Trap trap;


    private void Awake() {
        trap = GetComponentInParent<Trap>();
    }

    private void ActivateTrapEffectAnimationEvent() {
        trap.ActivateTrapEffect();
    }

    private void DisableTrapAnimationEvent() {
        trap.DisableTrap();
    }
}
