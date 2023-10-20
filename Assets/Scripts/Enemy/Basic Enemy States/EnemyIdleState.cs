using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    BasicEnemyMachine sm;
    float timer;
    public EnemyIdleState(BasicEnemyMachine em) : base(em){
        sm = em;
    }

    public override void Enter()
    {
        timer = 0;
        sm.character.Move(Vector3.zero);
    }
    public override void UpdateLogic()
    {
        timer += Time.deltaTime;
        if(sm.lifeSystem.life == 0){
            sm.animator.SetTrigger("Death");
            sm.ChangeState(sm.death);
        }
        else if(sm.LookAround() | sm.changeTo == "Follow"){
            sm.animator.SetTrigger("Walk");
            sm.ChangeState(sm.walk);
        }
        else if(timer >= 3){
            sm.animator.SetTrigger("Walk");
            sm.ChangeState(sm.patrol);
        }
        else if(GameObject.Find("Player").GetComponent<LifeSystem>().life <= 0){
            sm.animator.SetTrigger("Win");
            sm.ChangeState(sm.win);
        }
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(Physics.gravity);
    }
}
