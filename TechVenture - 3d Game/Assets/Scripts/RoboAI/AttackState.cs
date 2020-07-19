using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    float Damage = 1f;
    float Range = 70f;
    GameObject Origin;
    LineRenderer Laser;
    ParticleSystem Source;

    float rotationSpeed = 10.0f;
    public AttackState(GameObject _npc, Animator _anim, NavMeshAgent _agent, Transform _player)
         : base(_npc, _anim, _agent, _player)
    {
        name = STATES.ATTACK;
        agent.angularSpeed = 5.0f;
    }
    public override void Enter()
    {
        anim.SetBool("Action", true);
        anim.SetBool("Shoot", true);
        agent.isStopped = true;
        Origin = npc.GetComponent<AI>().Origin;
        Laser = npc.GetComponent<AI>().Laser;
        Source = npc.GetComponent<AI>().Source;
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log(name);
        if (npc.GetComponent<AI>().Health <= 0)
        {
            nextState = new DeadState(npc, anim, agent, player);
            stage = EVENT.EXIT;
        }
        //if (npc.GetComponent<AI>().Health < 10)
        //{
        //    anim.SetBool("Shoot", false);
        //    anim.SetBool("Hit", true);
        //}
            
        if (!PlayerInRange())
        {
            nextState = new PatrolState(npc, anim, agent, player);
            stage = EVENT.EXIT;
        }
        if (!CanShoot())
        {
            nextState = new PursueState(npc, anim, agent, player);
            stage = EVENT.EXIT;
        }
        if(player.GetComponent<PlayerRobotCollision>().Dying)
        {
            nextState = new IdleState(npc, anim, agent, player);
            stage = EVENT.EXIT;
        }
        Vector3 direction = player.position - npc.transform.position;
        float Angle = Vector3.Angle(npc.transform.forward, direction);
        direction.y = 0;
        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                     Time.deltaTime * rotationSpeed);
               ShootPlayer();
       
    }

    public override void Exit()
    {
        Debug.Log("Exit attack");
        agent.isStopped = false;
        //anim.SetBool("ShootPose", false);
        anim.SetBool("Action", false);
        anim.SetBool("Shoot", false);
        Laser.positionCount = 0;
        Source.Stop();
        base.Exit();
    }
    void ShootPlayer()
    {
        RaycastHit hit;
        Laser.positionCount = 1;
        Laser.SetPosition(0, Origin.transform.position);
        if (Physics.Raycast(Origin.transform.position, npc.transform.forward, out hit, Range))
        {
            anim.SetBool("Action", true);
            anim.SetBool("Shoot", true);
            Source.Play();
            Laser.positionCount++;
            Laser.SetPosition(1, hit.point);
            if (hit.collider.tag == "Player")
            {
                hit.transform.GetComponent<PlayerRobotCollision>().TakeDamage(Damage);
            }
        }
    }

}
