using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void Init(Unit unit);
    public abstract void Run();

    public virtual void Exit() { }

}
