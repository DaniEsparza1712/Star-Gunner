using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : State
{
    private BossMachine sm;
    public BossShoot(BossMachine bm): base(bm){
        sm = bm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Rage");
        sm.character.Move(Vector3.zero);
        int state = Random.Range(0, 2);
        if(state == 0){
            sm.nucleusAnimator.SetTrigger("Attack");
        }
        else{
            sm.nucleusAnimator.SetTrigger("Defense");
        }
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
        sm.character.Move(Vector3.zero);
    }
}
