using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : State
{
    private BossMachine sm;
    public BossDeath(BossMachine bm): base(bm){
        sm = bm;
    }

    public override void Enter()
    {
        sm.animator.SetTrigger("Death");
        sm.nucleusAnimator.SetTrigger("Idle");
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
