using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonAccessibles
{
    public enum GameState
    {
        BUILDMODE = 0, FIGHTMODE = 1
    }


    static GameState _State;
    public static GameState CurrentGameState
    {
        get
        {
            return _State;
        }

        set
        {
            _State = value;
            stateChangeHandler();
        }
    }

    public delegate void OnStateChange();
    public static OnStateChange stateChangeHandler;
}
