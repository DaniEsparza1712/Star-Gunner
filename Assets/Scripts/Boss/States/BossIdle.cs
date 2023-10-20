using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : State
{
    private BossMachine sm;
    float timer;
    public BossIdle(BossMachine bm): base(bm){
        sm = bm;
    }

    public override void Enter()
    {
        sm.animator.SetTrigger("Idle");
        sm.nucleusAnimator.SetTrigger("Idle");
        sm.ChangeTo("");
        timer = 0;
        sm.character.Move(Vector3.zero);
    }
    public override void UpdateLogic()
    {
        if(GameObject.Find("Player")){
            timer += Time.deltaTime;
        }
        if(timer >= 1.5f){
            GetNewAction();
        }
        if(sm.changeTo == "Chase"){
            sm.ChangeState(sm.walk);
        }
        else if(sm.changeTo == "Shoot"){
            sm.ChangeState(sm.shoot);
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
    void GetNewAction(){
        int actionCase = Random.Range(0, 2);

        switch(actionCase){
            case 0:
                sm.ChangeTo("Chase");
                break;
            case 1:
                sm.ChangeTo("Shoot");
                break;
        }
    }
}
