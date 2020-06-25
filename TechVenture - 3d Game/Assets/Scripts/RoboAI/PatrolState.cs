using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    float WanderRadius = 30f;
    float WanderDistance = 10f;
    Vector3 NPCPosition;


    public PatrolState(GameObject _npc, Animator _anim, NavMeshAgent _agent, Transform _player)
          : base(_npc, _anim, _agent, _player)
    {
        name = STATES.PATROL;
        agent.speed = 5f;
    }
    public override void Enter()
    {
        NPCPosition = Vector3.zero;
       
        if (RandomPoint(npc.transform.position, WanderRadius, out NPCPosition))
        {
            anim.SetFloat("Speed", 1f);
            agent.SetDestination(NPCPosition);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }    
        
        base.Enter();
    }
    public override void Update()
    {
        if (npc.GetComponent<AI>().Health <= 0)
        {
            nextState = new DeadState(npc, anim, agent, player);
            stage = EVENT.EXIT;
        }
        if (npc.GetComponent<AI>().BeingShot)
        {
            nextState = new PursueState(npc, anim, agent, player);
            stage = EVENT.EXIT;
        }
        
        if (Vector3.Distance(npc.transform.position, NPCPosition) < 7)
        {
            if (RandomPoint(npc.transform.position, WanderRadius, out NPCPosition))
            {
                anim.SetFloat("Speed", 1f);
                agent.SetDestination(NPCPosition);
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }
        }
        if (PlayerInRange())
        {
            nextState = new PursueState(npc, anim, agent, player);
            stage = EVENT.EXIT;
        }
    }
   

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, WanderDistance, 1))
        {
            result = hit.position;
            return true;
        }
        result = center;
        return false;
    }


    public override void Exit()
    {
        anim.SetFloat("Speed", 0);
        base.Exit();
    }
}