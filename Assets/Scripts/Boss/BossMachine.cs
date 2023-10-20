using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMachine : StateMachine
{
    [HideInInspector] public BossIdle idle;
    [HideInInspector] public BossChase walk;
    [HideInInspector] public BossAttack attack;
    [HideInInspector] public BossShoot shoot;
    [HideInInspector] public BossStun stun;
    [HideInInspector] public BossRecover recover;
    [HideInInspector] public BossDeath death;

    public GameObject target;
    public BossLifeSystem lifeSystem;
    public GameObject cartridge;
    public GameObject projectile;
    public GameObject nucleus;
    public Animator nucleusAnimator;
    public ParticleSystem explosion;
    public Collider attackCollider;
    public override void Start()
    {
        idle = new BossIdle(this);
        walk = new BossChase(this);
        attack = new BossAttack(this);
        shoot = new BossShoot(this);
        stun = new BossStun(this);
        recover = new BossRecover(this);
        death = new BossDeath(this);

        currentState = idle;
    }

    public void MakeExplosion(){
        Instantiate(explosion, transform.position, Quaternion.identity);
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
    public void LoadWin(){
        SceneManager.LoadScene("Win");
    }
}
