using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : State
{
    BasicEnemyMachine sm;
    float timer;
    public EnemyWalkState(BasicEnemyMachine em) : base(em){
        sm = em;
    }

    public override void Enter()
    {
        timer = 0;   
    }
    public override void UpdateLogic()
    {
        RaycastHit hit;
        timer += Time.deltaTime;
        if(sm.lifeSystem.life == 0){
            sm.animator.SetTrigger("Death");
            sm.ChangeState(sm.death);
        }
        else if(Vector3.Distance(sm.transform.position, sm.target.transform.position) < 2.8f){
            sm.animator.SetTrigger("Kick");
            sm.ChangeState(sm.kick);
        }
        else if(Vector3.Distance(sm.transform.position, sm.target.transform.position) > 3 && timer >= 0.8f){
            sm.animator.SetTrigger("Throw");
            sm.ChangeState(sm.enemyThrow);
        }
        else if(Physics.Raycast(sm.transform.position, sm.transform.forward, out hit, 2)){
            if(hit.transform.CompareTag("Wall")){
                sm.animator.SetTrigger("Kick");
                sm.ChangeState(sm.kick);
            }
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
        sm.character.Move(sm.transform.forward * sm.speed * Time.deltaTime);
        sm.character.Move(Physics.gravity);
    }
}
