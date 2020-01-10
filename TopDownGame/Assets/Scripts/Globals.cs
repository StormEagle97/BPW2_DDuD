using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals<T>
{
    public delegate void OnItemPickedUp(T input);
    public static OnItemPickedUp OnItemPickUpCaller;
}
