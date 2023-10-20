using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKick : State
{
    BasicEnemyMachine sm;
    public EnemyKick(BasicEnemyMachine em) : base(em){
        sm = em;
    }

    public override void Enter()
    {
        
    }
    public override void UpdateLogic()
    {
        if(sm.lifeSystem.life == 0){
            sm.animator.SetTrigger("Death");
            sm.ChangeState(sm.death);
        }
        else if(sm.changeTo == "Idle"){
            sm.ChangeTo("");
            sm.animator.SetTrigger("Idle");
            sm.ChangeState(sm.idle);
        }
        else if(sm.changeTo == "Walk"){
            sm.ChangeTo("");
            sm.animator.SetTrigger("Walk");
            sm.ChangeState(sm.walk);
        }
        else if(GameObject.Find("Player").GetComponent<LifeSystem>().life <= 0){
            sm.animator.SetTrigger("Win");
            sm.ChangeState(sm.win);
        }
    }
    public override void UpdatePhysics()
    {
        Vector3 direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
        sm.transform.LookAt(direction);
        sm.character.Move(Physics.gravity);
    }
}
