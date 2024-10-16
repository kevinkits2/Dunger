using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManagerEvents {

    public static event Action OnBuildModeSelectPerformed;
    public static void BuildModeSelectPerformed() => OnBuildModeSelectPerformed?.Invoke();

    public static event Action OnBuildModeDeselectPerformed;
    public static void BuildModeDeselectPerformed() => OnBuildModeDeselectPerformed?.Invoke();

    public static event Func<Vector2> OnCameraMovementVectorRequested;
    public static Vector2 RequestCameraMovementVector() => OnCameraMovementVectorRequested?.Invoke() ?? Vector2.zero;

    public static event Action OnPausePerformed;

    public static void PausePerformed() => OnPausePerformed?.Invoke();
}
