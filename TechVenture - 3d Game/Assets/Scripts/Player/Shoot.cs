using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public LineRenderer Laser;
    public ParticleSystem Source;
    public float ShootingHeight;
    //public GameObject Floor;
    //public GameObject Barrier;

    GameObject Robot;
    AI RobotAI;
    Animator PlayerAnim;
    float Damage = 10f;
    float Range = 100f;

    enum Direction
    {
        LEFT, RIGHT
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            ShootPlayer();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (RobotAI != null)
            {
                RobotAI.BeingShot = false;
            }
            Laser.positionCount = 0;
            Source.Stop();
            PlayerAnim.SetBool("shoot", false);
           
        }
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Crouch();
        //}
    }
    void ShootPlayer()
    {
        PlayerAnim.SetBool("shoot", true);
        RaycastHit hit;
        
        Laser.positionCount = 1;
        Laser.SetPosition(0, Laser.transform.position);
       
        if(Physics.Raycast(transform.position + transform.up * ShootingHeight, transform.forward, out hit, Range))
        {
            Source.Play();
            Laser.positionCount++;
            Laser.SetPosition(1, hit.point);
            if(hit.collider.tag == "Robot")
            {
                RobotAI = hit.transform.GetComponent<AI>();
                RobotAI.TakeDamage(Damage);
                //RobotAI.BeingShot = true;
                if (Robot != null && Robot != hit.collider.gameObject)
                {
                    ShootDifferentRobot(Robot);
                }
                Robot = hit.collider.gameObject;
                
            }
        }
       
    }
    //void Crouch()
    //{
    //    float Sight = 10;
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position + transform.up, transform.forward, out hit, Sight))
    //    {
    //        if (hit.collider.tag == "Barrier")
    //        {
    //            Direction m_Dir = CrouchDirection(hit.collider.gameObject, Floor);
    //            //Debug.Log(hit.collider.transform.position);
    //            switch (m_Dir)
    //            {
    //                case Direction.LEFT:
    //                    Debug.Log("LeftCrouch");
    //                    break;
    //                case Direction.RIGHT:
    //                    Debug.Log("RightCrouch");
    //                    break;
    //            }
    //        }
    //    }
    //}
    //Direction CrouchDirection(GameObject Barrier, GameObject Floor)
    //{
    //    float DotProduct = Vector3.Dot(transform.forward.normalized, Barrier.transform.forward.normalized);
    //    Direction BarrierDir = GetBarrierDirection(Barrier, Floor);
    //    if (DotProduct >= 0.8)
    //    {
    //        Debug.Log("Inverse");
    //        return InverseDirection(BarrierDir);
    //    }
    //    Debug.Log("Dir");
    //    return BarrierDir;
    //}
    //Direction GetBarrierDirection(GameObject Barrier, GameObject Floor)
    //{
    //    if(Barrier.transform.localPosition.x >= Floor.transform.localPosition.x)
    //    {
    //        return Direction.LEFT;
    //    }
    //    return Direction.RIGHT;
    //}
    //Direction InverseDirection(Direction m_Dir)
    //{
    //    if (m_Dir == Direction.LEFT)
    //        return Direction.RIGHT;
    //    return Direction.LEFT;
    //}
    void ShootDifferentRobot(GameObject PreviousRobot)
    {
        PreviousRobot.GetComponent<AI>().BeingShot = false;
    }
}
