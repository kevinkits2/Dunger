using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManagerEvents {

    public static event Action<GameState> OnGameStateChanged;
    public static void ChangeGameState(GameState gameState) => OnGameStateChanged?.Invoke(gameState);

}