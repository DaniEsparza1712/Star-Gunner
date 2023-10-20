using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRecover : State
{
    private BossMachine sm;
    public BossRecover(BossMachine bm) : base(bm){
        sm = bm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Recover");
        sm.character.Move(Vector3.zero);
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Idle"){
            sm.ChangeState(sm.idle);
        }
        else if(sm.lifeSystem.GetLifePoints == 0){
            sm.ChangeState(sm.death);
        }
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(Physics.gravity);
    }
}
