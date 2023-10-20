using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : State
{
    private BossMachine sm;
    float timer;
    public BossChase(BossMachine bm) : base(bm){
        sm = bm;
    }
    public override void Enter()
    {
        sm.target = GameObject.Find("Player");
        sm.animator.SetTrigger("Walk");
        sm.nucleusAnimator.SetTrigger("Idle");
        timer = 0;
    }
    public override void UpdateLogic()
    {
        timer += Time.deltaTime;
        if(timer >= 2.0f || Vector3.Distance(sm.transform.position, sm.target.transform.position) <= 3.0f){
            sm.ChangeState(sm.attack);
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
        Vector3 direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
        sm.transform.LookAt(direction);
        sm.character.Move(sm.transform.forward * sm.speed * Time.deltaTime);
        sm.character.Move(Physics.gravity);
    }
}
