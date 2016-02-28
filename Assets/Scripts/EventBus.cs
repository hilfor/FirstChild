using UnityEngine;
using System.Collections;

public static class EventBus {
    public static Signal<GameObject> BinCleared = new Signal<GameObject>();
}
