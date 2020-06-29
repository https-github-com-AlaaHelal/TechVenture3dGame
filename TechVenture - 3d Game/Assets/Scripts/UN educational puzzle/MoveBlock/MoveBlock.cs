using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBlock : EventTrigger
{
    GameObject BoardGame;
    GameObject LaserInBox;
    GameObject Box;
    Animator Boxanimator;


    public bool Selected = false;
    public bool CanMove = false;
    public UnBlock.Orientation b_orientation;
    public UnBlock.Type b_type;
    public UnBlock.Size b_Size;
    GameObject GameManager;
    BlockManager ManagerScript;
    List<UnBlock.Direction> m_directions;
    UnBlock.Direction movement;

    Vector3 InitialPositionCheck;
    Vector3 InitialPositionAdjust;
    UnBlock UnBlockScript;
    float MovedDistance;
    //float MaxDistance;
    float EmptyWidth;
    float WinPosition;
    public float Height;
    // Start is called before the first frame update
    void Start()

    {
       
        UnBlockScript = GetComponent<UnBlock>();
        InitialPositionCheck = Vector3.zero;
        b_orientation = UnBlockScript.orientation;
        b_type = UnBlockScript.type;
        b_Size = UnBlockScript.size;
        Height = UnBlockScript.Height;
        GameManager = GameObject.Find("BlockBoard");
        ManagerScript = GameManager.GetComponent<BlockManager>();
        m_directions = new List<UnBlock.Direction>();
        EmptyWidth = UnBlockScript.EmptyWidth;
        WinPosition = transform.position.x + EmptyWidth * 4;
        //Debug.Log(EmptyWidth);
        //Debug.Log(transform.position);
    }
    //private void Update()
    //{
    //    if (m_directions.Count > 0)
    //    {
    //        foreach (UnBlock.Direction dir in m_directions)
    //            Debug.Log(gameObject + " " + dir);
    //    }
    //}



 

    public override void OnPointerDown(PointerEventData eventData)
    {
        InitialPositionCheck = transform.position;
        InitialPositionAdjust = transform.position;
        Selected = true;
        m_directions.Clear();
        m_directions = ManagerScript.GetAvailableDirections(gameObject);
        MovedDistance = EmptyWidth;
        Debug.Log(transform.position);
        Debug.Log(InitialPositionCheck.x + EmptyWidth);
        Debug.Log(EmptyWidth);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        Selected = false;
        //Debug.Log("Up");
        AdjustPosition();
        Win();
    }
    public override void OnDrag(PointerEventData eventData)
    {
        Vector3 drag = eventData.delta;
        //float Speed = MovedDistance / Time.deltaTime;
        float Speed = 0.6f;
        //Debug.Log(drag.x);
        //if (MovedDistance <= 0)
        //{
        //    m_directions = ManagerScript.GetAvailableDirections(gameObject);
        //    //Debug.Log(MovedDistance);
        //}

        //Debug.Log(MovedDistance);
        switch (b_orientation)
        {
            case UnBlock.Orientation.HORIZONTAL:
                Move(drag.x);
                if (CanMove)
                {
                    transform.position += new Vector3(drag.x * Speed, 0, 0);
                   // Debug.Log("MoveX");
                }
                break;
            case UnBlock.Orientation.VERTICAL:
                Move(drag.y);
                if (CanMove)
                {
                    transform.position += new Vector3(0, drag.y * Speed, 0);
                }
                break;
        }
        if (Check())
        {
            Debug.Log(transform.position + " Check");
            //Debug.Log(transform.position);
            CanMove = false;
            m_directions.Clear();
            m_directions = ManagerScript.GetAvailableDirections(gameObject);
            InitialPositionCheck = transform.position;
            InitialPositionAdjust = transform.position;
        }
        
    }
    //Vector3 ClampXPosition(Vector3 position)
    //{
    //    float Distance = EmptyWidth / 2 + Height / 2;
    //    if (movement == UnBlock.Direction.LEFT)
    //        return new Vector3(InitialPosition.x - Distance, InitialPosition.y, InitialPosition.z);

    //}
    void Move(float drag)
    {
        CanMove = false;

        foreach (UnBlock.Direction direction in m_directions)
        {
            if (drag > 0)
            {
                if (direction == UnBlock.Direction.TOP || direction == UnBlock.Direction.RIGHT)
                    CanMove = true;
            }
            if (drag < 0)
            {
                if (direction == UnBlock.Direction.BOTTOM || direction == UnBlock.Direction.LEFT)
                    CanMove = true;
            }
        }
    }

    bool Check()
    {
        //float Distance = EmptyWidth / 2 + Height / 2;
        switch (b_orientation)
        {
            case UnBlock.Orientation.HORIZONTAL:
                if (transform.position.x >= InitialPositionCheck.x + EmptyWidth)
                {
                    Debug.Log("right");
                    transform.position = new Vector3(InitialPositionCheck.x + EmptyWidth, transform.position.y, transform.position.z);
                    return true;
                }
                else if (transform.position.x <= InitialPositionCheck.x - EmptyWidth)
                {
                    Debug.Log("left");
                    transform.position = new Vector3(InitialPositionCheck.x - EmptyWidth, transform.position.y, transform.position.z);
                    return true;
                }
                break;
            case UnBlock.Orientation.VERTICAL:
                if (transform.position.y >= InitialPositionCheck.y + EmptyWidth)
                {
                    Debug.Log("top");
                    transform.position = new Vector3(transform.position.x, InitialPositionCheck.y + EmptyWidth, transform.position.z);
                    return true;
                }
                else if (transform.position.y <= InitialPositionCheck.y - EmptyWidth)
                {
                    Debug.Log("bottom");
                    transform.position = new Vector3(transform.position.x, InitialPositionCheck.y - EmptyWidth, transform.position.z);
                    return true;
                }
                break;
        }
        return false;
    }
    void AdjustPosition()
    {
        switch (b_orientation)
        {
            case UnBlock.Orientation.HORIZONTAL:
                if (transform.position.x > InitialPositionAdjust.x)
                {
                    transform.position = new Vector3(InitialPositionAdjust.x + EmptyWidth, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < InitialPositionAdjust.x)
                {
                    transform.position = new Vector3(InitialPositionAdjust.x - EmptyWidth, transform.position.y, transform.position.z);
                }
                break;
            case UnBlock.Orientation.VERTICAL:
                if (transform.position.y > InitialPositionAdjust.y)
                {
                    transform.position = new Vector3(transform.position.x, InitialPositionAdjust.y + EmptyWidth, transform.position.z);
                }
                else if (transform.position.y < InitialPositionAdjust.y)
                {
                    transform.position = new Vector3(transform.position.x, InitialPositionAdjust.y - EmptyWidth, transform.position.z);
                }
                break;
        }
    }
    bool Win()
    {
        if(b_type == UnBlock.Type.RED && transform.position.x == WinPosition)
        {

            Debug.Log("Win!");
            Time.timeScale = 1f;
            BoardGame = GameObject.FindGameObjectWithTag("BlockBoard");
            Destroy(BoardGame);
            Box = GameObject.FindGameObjectWithTag("Box");
            Boxanimator = Box.GetComponentInParent<Animator>();
            Boxanimator.SetBool("open", true);
            Boxanimator.SetFloat("speed", 1);
            LaserInBox = GameObject.FindGameObjectWithTag("LaserArm");
            LaserInBox.SetActive(true);


        


            return true;
        }
        return false;
    }
}
