using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class AgentAI : MonoBehaviour
{
    public string playerTag = "Player";

    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    //public NavMeshAgent navAgent;


    private Transform target;
    private float timer;

    public bool isCilivian;

#region AI States
    [HideInInspector]
    public EnemyState currentState;


    [HideInInspector]
    public IdleState idleState;

    [HideInInspector]
    public TalkState talkState;
#endregion

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        //navAgent = GetComponent<NavMeshAgent>();

        idleState = new IdleState(this);
        talkState = new TalkState(this);

        currentState = idleState;
    }

    // Update is called once per frame
    void Update()
    {
        //currentState.UpdateState();
    }


    void OnTriggerEnter(Collider other)
    {
        currentState.StateOnTriggerEnter(other, playerTag);
    }

    void OnTriggerStay(Collider other)
    {
        currentState.StateOnTriggerStay(other, playerTag);
    }

    void OnTriggerExit(Collider other)
    {
        currentState.StateOnTriggerExit(other, playerTag);
    }

    public void SetState(EnemyState _em) {
        currentState = _em;
    }


    public void ChangeStateByChance(EnemyState _enmA, EnemyState _enmB, int _chancePercent)
    {
        int rand = Random.Range(0, 101);
        currentState = (rand <= _chancePercent) ? _enmA : _enmB;
    }

} // end class AgentAI