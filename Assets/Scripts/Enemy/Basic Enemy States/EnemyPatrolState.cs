using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : State
{
    public BasicEnemyMachine sm;
    Vector3 patrolVector;
    int direction = 1;
    public EnemyPatrolState(BasicEnemyMachine em): base(em){
        sm = em;
    }
    public override void Enter()
    {
        patrolVector = new Vector3(sm.transform.position.x, sm.transform.position.y, sm.transform.position.z) + -7 * sm.transform.forward;

        sm.patrolPos.transform.position = patrolVector;
        sm.target = sm.patrolPos;
    }

    public override void UpdateLogic()
    {
        RaycastHit hit;
        if(Vector3.Distance(sm.transform.position, sm.target.transform.position) < 1){
            sm.animator.SetTrigger("Idle");
            sm.ChangeState(sm.idle);
        }
        else if(Physics.Raycast(sm.transform.position, sm.transform.forward, out hit, 2)){
            if(hit.transform.CompareTag("Wall") | hit.transform.CompareTag("Enemy")){
                sm.animator.SetTrigger("Idle");
                sm.ChangeState(sm.idle);
            }
        }

        if(sm.lifeSystem.life == 0){
            sm.animator.SetTrigger("Death");
            sm.ChangeState(sm.death);
        }
        else if(sm.LookAround() | sm.changeTo == "Follow"){
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
        sm.character.Move(sm.transform.forward * sm.speed * Time.deltaTime);
        sm.character.Move(Physics.gravity);
    }
}
