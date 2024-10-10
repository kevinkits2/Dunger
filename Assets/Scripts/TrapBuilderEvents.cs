using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrapBuilderEvents {

    public static event Action OnTrapBuilt;
    public static void BuildTrap() => OnTrapBuilt?.Invoke();

    public static event Action OnTrapDeselected;
    public static void DeselectTrap() => OnTrapDeselected?.Invoke();

    public static event Func<bool> OnPlacementAvailabilityRequested;
    public static bool RequestPlacementAvailability() => OnPlacementAvailabilityRequested?.Invoke() ?? false; 
}
