using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour {

    protected const string ACTIVATE_TRAP = "Activate";
    protected const string DISABLE_TRAP = "Disable";

    [SerializeField] protected int trapDamage;
    [SerializeField] protected Animator trapAnimator;
    [SerializeField] protected Animator trapEffectAnimator;


    public abstract void ActivateTrap();
    public abstract void DisableTrap();

    public abstract void ActivateTrapEffect();

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        ActivateTrap();
    }

    protected virtual void OnTriggerExit2D(Collider2D collision) {
        DisableTrap();
    }
}
