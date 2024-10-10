using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : Trap {

    public override void ActivateTrap() {
        trapAnimator.SetTrigger(ACTIVATE_TRAP);
    }

    public override void DisableTrap() {
        trapAnimator.SetTrigger(DISABLE_TRAP);
    }

    public override void ActivateTrapEffect() {
        trapEffectAnimator.SetTrigger(ACTIVATE_TRAP);
    }

    protected override void OnTriggerExit2D(Collider2D collision) {
        //Leave empty
    }
}
