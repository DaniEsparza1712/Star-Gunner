using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStun : State
{
    private BossMachine sm;
    private float recoveryTime;
    private float timer;
    public BossStun(BossMachine bm) : base(bm){
        sm = bm;
    }
    public override void Enter()
    {
        timer = 0;
        recoveryTime = 5;
        sm.character.Move(Vector3.zero);
        sm.animator.SetTrigger("Damage");
        sm.nucleusAnimator.SetTrigger("Idle");
        SpawnCartridges();
    }
    public override void UpdateLogic()
    {
        timer += Time.deltaTime;
        if(timer >= recoveryTime){
            sm.ChangeState(sm.recover);
        }
        else if(sm.lifeSystem.GetLifePoints == 0){
            sm.ChangeState(sm.death);
        }
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(Physics.gravity);
    }
    private void SpawnCartridges(){
        Vector3 basePos = new Vector3(0,1,0);
        GameObject.Instantiate(sm.cartridge, sm.transform.Find("CartridgeSpawn1").position + basePos, Quaternion.identity);
        GameObject.Instantiate(sm.cartridge, sm.transform.Find("CartridgeSpawn2").position + basePos, Quaternion.identity);
        GameObject.Instantiate(sm.cartridge, sm.transform.Find("CartridgeSpawn3").position + basePos, Quaternion.identity);
    }
}
