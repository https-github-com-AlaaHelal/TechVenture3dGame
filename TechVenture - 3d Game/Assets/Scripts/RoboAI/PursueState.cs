using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PursueState : State
{
    public PursueState(GameObject _npc, Animator _anim, NavMeshAgent _agent, Transform _player)
         : base(_npc, _anim, _agent, _player)
    {
        name = STATES.PURSUE;
        agent.speed = 6.0f;
    }

    public override void Enter()
    {
        agent.speed = 6;
        anim.SetFloat("Speed", 2);
        base.Enter();
    }
    public override void Update()
    {
        agent.SetDestination(player.position);

        if (npc.GetComponent<AI>().Health <= 0)
        {
            nextState = new DeadState(npc, anim, agent, player);
            stage = EVENT.EXIT;
        }
        if (CanShoot())
        {
            if (agent.hasPath)
            {
                nextState = new AttackState(npc, anim, agent, player);
                stage = EVENT.EXIT;
            }
            else if (!PlayerInRange())
            {
                nextState = new PatrolState(npc, anim, agent, player);
            }
        }

    }
    public override void Exit()
    {
        anim.SetFloat("Speed", 0);
        base.Exit();
    }
}
