using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : State
{
    BossMachine sm;
    public BossAttack(BossMachine bm) : base(bm){
        sm = bm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Hit");
        sm.nucleusAnimator.SetTrigger("Attack");
        sm.character.Move(Vector3.zero);
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Idle"){
            sm.ChangeState(sm.idle);
        }
        else if(sm.lifeSystem.GetStunPoints == 0){
            sm.ChangeState(sm.stun);
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
