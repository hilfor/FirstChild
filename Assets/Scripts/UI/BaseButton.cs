using UnityEngine;
using System.Collections;

public abstract class BaseButton : MonoBehaviour
{
    public BaseMenu _menu;

    public abstract void ButtonPressed();

}
