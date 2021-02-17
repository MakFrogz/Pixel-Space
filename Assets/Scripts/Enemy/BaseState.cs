using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseState 
{
    protected GameObject gameObject;
    protected Transform transform;

    protected BaseState(GameObject _gameObject)
    {
        this.gameObject = _gameObject;
        this.transform = gameObject.transform;
    }

    public virtual void Enter() { }
    public abstract Type Tick();
}
