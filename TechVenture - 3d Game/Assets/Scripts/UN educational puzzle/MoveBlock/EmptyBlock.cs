using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBlock : MonoBehaviour
{
    UnBlock.Orientation b__orientation;
    enum Direction
    {
        RIGHT, LEFT, TOP, BOTTOM, NONE
    }
   
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("trigger");
    //    if(collision.tag == "UnBlock")
    //    {
    //        Debug.Log("Swap");
    //        UnBlock BlockScript = collision.gameObject.GetComponent<UnBlock>();
    //        b__orientation = BlockScript.orientation;
    //        //CheckDirection(collision.gameObject.transform);
    //        Swap(CheckDirection(collision.gameObject.transform), BlockScript.Height);
    //        //Debug.Log(CheckDirection(collision.gameObject.transform));
           
    //    }
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger");
        if (other.tag == "UnBlock")
        {
            //Debug.Log("Swap" + gameObject);
            UnBlock BlockScript = other.gameObject.GetComponent<UnBlock>();
            b__orientation = BlockScript.orientation;
            Swap(CheckDirection(other.gameObject.transform), BlockScript.Height);
        }
    }
    Direction CheckDirection(Transform Block)
    {
        switch (b__orientation)
        {
            case UnBlock.Orientation.HORIZONTAL:
                if (transform.position.x < Block.transform.position.x)
                    return Direction.RIGHT;
                return Direction.LEFT;
            case UnBlock.Orientation.VERTICAL:
                if (transform.position.y < Block.transform.position.y)
                    return Direction.TOP;
                return Direction.BOTTOM;
        }
        return Direction.NONE;
    }
    void Swap(Direction dir, float Height)
    {
        switch (dir)
        {
            case Direction.LEFT:
                transform.position = new Vector3(transform.position.x - Height, transform.position.y, transform.position.z);
                break;
            case Direction.RIGHT:
                transform.position = new Vector3(transform.position.x + Height, transform.position.y, transform.position.z);
                break;
            case Direction.TOP:
                transform.position = new Vector3(transform.position.x, transform.position.y + Height, transform.position.z);
                break;
            case Direction.BOTTOM:
                transform.position = new Vector3(transform.position.x, transform.position.y - Height, transform.position.z);
                break;
        }
    }
}
