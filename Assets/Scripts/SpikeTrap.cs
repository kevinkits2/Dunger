using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap {

    public override void Build() {
        throw new System.NotImplementedException();
    }

    public override void ActivateTrap() {
        trapEffectAnimator.SetTrigger(ACTIVATE_TRAP);
    }

    public override void ActivateTrapEffect() {
        throw new System.NotImplementedException();
    }

    public override void DisableTrap() {
        trapEffectAnimator.SetTrigger(DISABLE_TRAP);
    }
}
