using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour {

    [SerializeField] private bool canHold;
    [SerializeField] private bool locked;
    [SerializeField] private bool pushable;

    public bool GetCanHold()
    {
        return canHold;
    }

    public bool IsLocked()
    {
        return locked;
    }

    public bool IsPushable()
    {
        return pushable;
    }

    public void SetLocked(bool value)
    {
        locked = value;
    }
}
