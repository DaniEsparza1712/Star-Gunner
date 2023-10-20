using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMachine : StateMachine
{
    [HideInInspector] public EnemyIdleState idle;
    [HideInInspector] public EnemyDeathState death;
    [HideInInspector] public EnemyWalkState walk;
    [HideInInspector] public EnemyKick kick;
    [HideInInspector] public EnemyPatrolState patrol;
    [HideInInspector] public EnemyThrowState enemyThrow;
    [HideInInspector] public EnemyWinState win;
    public LayerMask onlyPlayer;
    [HideInInspector] public GameObject target;
    [HideInInspector]public GameObject patrolPos;
    public ParticleSystem explosion;
    public Collider attackCollider;
    public EnemyProjectile projectile;
    public Vector3 projectileSpawnPos;
    public LifeSystem lifeSystem;
    public override void Start()
    {
        idle = new EnemyIdleState(this);
        death = new EnemyDeathState(this);
        walk = new EnemyWalkState(this);
        kick = new EnemyKick(this);
        patrol = new EnemyPatrolState(this);
        enemyThrow = new EnemyThrowState(this);
        win = new EnemyWinState(this);
        
        patrolPos = Instantiate(new GameObject(), transform.position, Quaternion.identity);

        currentState = idle;
    }

    public void SetAttackCollision(int collisionCase){
        switch(collisionCase){
            case 1:
                attackCollider.enabled = true;
                break;
            case 2:
                attackCollider.enabled = false;
                break;
        }
    }
    public void MakeExplosion(){
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
    public void ThrowProjectile(){
        Instantiate(projectile.gameObject, transform.position + projectileSpawnPos, Quaternion.identity);
    }

    public bool LookAround(){
        RaycastHit hit;
        if(Physics.BoxCast(transform.position, Vector3.one * 1.5f, transform.forward, out hit, Quaternion.identity, 6)){
            if(hit.transform.CompareTag("Wall")){
                return false;
            }
            else if(hit.transform.CompareTag("Player")){
                target = hit.transform.gameObject;
                return true;
            }
        }
        return false;
    }
    public void AddPoints(){
        PointManager.instance.points += 10;
    }
}
