using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWinState : State
{
    public BasicEnemyMachine sm;
    public EnemyWinState(BasicEnemyMachine bm): base(bm){
        sm = bm;
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
        sm.character.Move(Physics.gravity);
    }
}
