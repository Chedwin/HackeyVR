using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TalkState : EnemyState
{
    //AgentAI agentAI;

    public TalkState(AgentAI _ai)
    {
        this.agentAI = _ai;
    }

    public void StartTalk()
    {
        agentAI.anim.SetTrigger("PlayerTalk");
    }

    public override void UpdateState()
    {


    }

    public override void StateOnTriggerEnter(Collider _other, string _tag)
    {
        // empty
    }

    public override void StateOnTriggerStay(Collider _other, string _tag)
    {
        if (_other.gameObject.tag != _tag)
            return;

        agentAI.navAgent.transform.LookAt(_other.gameObject.transform);
    }

    public override void StateOnTriggerExit(Collider _other, string _tag)
    {
        if (_other.gameObject.tag != _tag)
            return;

        agentAI.anim.SetBool("PlayerTalk", false);
        agentAI.ChangeStateByChance(agentAI.wanderState, agentAI.idleState, 30);
    }

} // end class TalkState
