using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals<T>
{
    public delegate void OnItemPickedUp(T input);
    public static OnItemPickedUp OnItemPickUpCaller;

    public delegate void OnHighScoreChanged(T newScore);
    public static OnHighScoreChanged OnHighScoreChangedHandler;

    public delegate void OnHighScorePointsChanged(T newScore);
    public static OnHighScorePointsChanged OnHighScorePointsChangedHandler;
}
