using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected AgentAI agentAI;

    public abstract void UpdateState();

    public abstract void StateOnTriggerEnter(Collider _other, string _tag);
    public abstract void StateOnTriggerStay(Collider _other, string _tag);

    public abstract void StateOnTriggerExit(Collider _other, string _tag);

} // end class EnemyState