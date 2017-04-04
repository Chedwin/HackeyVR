using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    //private AgentAI agentAI;

    public IdleState(AgentAI _ai)
    {
        this.agentAI = _ai;
    }

    public override void UpdateState()
    {
        // empty
    }

    public override void StateOnTriggerEnter(Collider _other, string _tag)
    {
        if (_other.gameObject.tag != _tag)
            return;

        agentAI.currentState = agentAI.talkState;
        agentAI.talkState.StartTalk();
    }

    public override void StateOnTriggerStay(Collider _other, string _tag)
    {
        // empty
    }

    public override void StateOnTriggerExit(Collider _other, string _tag)
    {
        // empty
    }

} // end class Idle

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//public class StartWalk : Transition
//{
//    public ConditionFloat walkSpeed;
//}