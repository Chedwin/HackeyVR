using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : EnemyState
{
    public float timer = 0.0f;
    public float wanderRadius = 50.0f;
    public float wanderTimer = 10.0f;

    public WanderState(AgentAI _ai)
    {
        this.agentAI = _ai;
    }

    public override void UpdateState()
    {
        
    }

    public override void StateOnTriggerEnter(Collider _other, string _tag)
    {
        if (_other.gameObject.tag != _tag)
            return;

        agentAI.navAgent.velocity = Vector3.zero;
        agentAI.anim.SetFloat("Speed", 0.0f);
        agentAI.currentState = agentAI.talkState;
        agentAI.talkState.StartTalk();
    }

    public override void StateOnTriggerStay(Collider _other, string _tag)
    {
        agentAI.navAgent.velocity = Vector3.zero;
        //agentAI.anim.SetFloat("Speed", 0.0f);
    }

    public override void StateOnTriggerExit(Collider _other, string _tag)
    {
        // should be empty
    }

    void Wander()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(agentAI.transform.position, wanderRadius, -1);
            agentAI.navAgent.SetDestination(newPos);
            timer = 0;
        }
        agentAI.anim.SetFloat("Speed", agentAI.navAgent.velocity.magnitude);
    }

    static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

} // end class Idle
