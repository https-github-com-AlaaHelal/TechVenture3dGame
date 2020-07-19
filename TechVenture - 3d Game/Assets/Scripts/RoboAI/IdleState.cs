using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public IdleState(GameObject _npc, Animator _anim, NavMeshAgent _agent, Transform _player)
         : base(_npc, _anim, _agent, _player)
    {
        name = STATES.IDLE;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        Debug.Log(name);
        if (player.GetComponent<PlayerRobotCollision>().Dying)
        {
            agent.isStopped = true;
            anim.SetBool("Action", true);
        }
        else
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
            if (PlayerInRange())
            {
                nextState = new PursueState(npc, anim, agent, player);
                stage = EVENT.EXIT;
            }
            else if (Random.Range(1, 100) < 10)
            {
                nextState = new PatrolState(npc, anim, agent, player);
                stage = EVENT.EXIT;
            }
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
