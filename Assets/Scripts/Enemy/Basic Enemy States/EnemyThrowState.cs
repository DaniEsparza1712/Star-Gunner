using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowState : State
{
    public BasicEnemyMachine sm;
    public EnemyThrowState(BasicEnemyMachine em): base(em){
        sm = em;
    }
    public override void Enter()
    {
        sm.character.Move(Vector3.zero);
    }
    public override void UpdateLogic()
    {
        if(sm.lifeSystem.life == 0){
            sm.animator.SetTrigger("Death");
            sm.ChangeState(sm.death);
        }
        else if(sm.changeTo == "Walk"){
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
