using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    //public GameObject[] Robots;
    //public AI[] RobotAI;

    //bool RobotAlert = false;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    foreach(AI AIScript in RobotAI)
    //    {
    //        if (AIScript.BeingShot)
    //        {
    //            RobotAlert = true;
    //        }
    //    }
    //    if (RobotAlert)
    //    {
    //        foreach(AI AIScript in RobotAI)
    //        {
    //            AIScript.BeingShot = true;
    //        }
    //    }
    //}

    public static RobotManager instance;
    public GameObject RobotPrefab;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    public void InstantiateRobots(int RobotNumber)
    {
        for (int i = 0; i < RobotNumber; i++)
        {
            Instantiate(RobotPrefab);
            Debug.Log("Robot");
        }
    }
}
