using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine: MonoBehaviour
{
    public CharacterController character;
    public Animator animator;
    public float speed;

    [HideInInspector]
    public string changeTo = "";
    [HideInInspector]
    public State currentState;

    public virtual void Start() {
        /*currentState = idle;
        currentState.Enter(this);*/
    }

    public virtual void Update() {
        currentState.UpdateLogic();
    }
    private void LateUpdate() {
        currentState.UpdatePhysics();
    }
    public void ChangeState(State state){
        currentState = state;
        currentState.Enter();
    }
    public void ChangeTo(string state){
        changeTo = state;
    }
}