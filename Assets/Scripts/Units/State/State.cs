using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void Init() { }
    public abstract void Run();

}
