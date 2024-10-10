using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIManagerEvents {

    public static event Action<TrapSO> OnTrapButtonClicked;
    public static void TrapButtonClicked(TrapSO trapSO) => OnTrapButtonClicked?.Invoke(trapSO);

    public static event Action OnPlayModeButtonClicked;
    public static void EnterPlayMode() => OnPlayModeButtonClicked?.Invoke();
}
