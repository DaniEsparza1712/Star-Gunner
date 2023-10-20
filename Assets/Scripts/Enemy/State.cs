using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public State(StateMachine sm){

    }
    public abstract void Enter();
    public abstract void UpdateLogic();
    public abstract void UpdatePhysics();
}
