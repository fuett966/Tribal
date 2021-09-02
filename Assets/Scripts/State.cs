using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    // gameplay parametrs
    public bool IsFinished {get ; protected set; }
    [HideInInspector]public Character Character;

    public virtual void Init(){ }

    public abstract void Run();
}
