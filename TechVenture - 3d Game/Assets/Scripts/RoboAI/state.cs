using UnityEngine;
using UnityEngine.AI;

public class State
{
  
    public enum STATES
    {
        IDLE, PATROL, ATTACK, PURSUE, DEAD
    }
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }
    protected STATES name;
    protected EVENT stage;
    protected GameObject npc;
    protected Transform player;
    protected Animator anim;
    protected NavMeshAgent agent;
    protected State nextState;
    

    float VisiableDistance = 70.0f;
    float FieldOfView = 200.0f;
    float AttackDistance = 50.0f;


    public State(GameObject _npc, Animator _anim, NavMeshAgent _agent, Transform _player)
    {
        npc = _npc;
        anim = _anim;
        agent = _agent;
        player = _player;
    }
    
    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }


    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool PlayerInRange()
    {
        Vector3 direction = player.position - npc.transform.position;
        float NPCtoPlayerAngle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude <= VisiableDistance && NPCtoPlayerAngle <= FieldOfView)
        {
            return true;
        }
        return false;
    }

    public bool CanShoot()
    {
        float Distance = Vector3.Distance(npc.transform.position, player.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(npc.transform.position + npc.transform.up * 3, npc.transform.forward, out hit, AttackDistance))
        {
            if (hit.collider.tag == "Player")
            {
                return true;
            }
        }
        else if (Distance <= 30f)
            return true;
        return false;
    }

   
}

