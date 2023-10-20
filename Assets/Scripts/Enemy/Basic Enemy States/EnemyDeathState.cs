using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : State
{
    BasicEnemyMachine sm;
    public EnemyDeathState(BasicEnemyMachine em) : base(em){
        sm = em;
    }

    public override void Enter()
    {
        sm.character.Move(Vector3.zero);
    }
    public override void UpdateLogic()
    {

    }
    public override void UpdatePhysics()
    {
        
    }
}
