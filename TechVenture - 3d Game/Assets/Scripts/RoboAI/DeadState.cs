using UnityEngine.AI;
using UnityEngine;

public class DeadState : State
{
    public DeadState(GameObject _npc, Animator _anim, NavMeshAgent _agent, Transform _player)
        : base(_npc, _anim, _agent, _player)
    {
        name = STATES.DEAD;
    }

    public override void Enter()
    {
        //anim.SetBool("Action", true);
        anim.SetBool("Death", true);
        agent.isStopped = true;
        player.GetComponent<PlayerRobotCollision>().IncrementHealth();
        base.Enter();
        stage = EVENT.EXIT;
    }
    
    public override void Exit()
    {
        Debug.Log("Exit dead");
        //particle system
        npc.GetComponent<AI>().Dead = true;
        base.Exit();
    }

}
