using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    


    public GameObject[] empty;
    RectTransform EmptyTransform;
    public float EmptyWidth;

    // Start is called before the first frame update
    void Start()
    {
        //if (empty.Length > 0 )
        //    EmptyWidth = empty[0].GetComponent<RectTransform>().rect.width;
        EmptyWidth = 50;
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public List<UnBlock.Direction> GetAvailableDirections(GameObject Block)
    {
        UnBlock BlockScript = Block.GetComponent<UnBlock>();

        float distance = BlockScript.Height / 2 + EmptyWidth / 2;
        
        List<UnBlock.Direction> directions = new List<UnBlock.Direction>();
        switch (BlockScript.orientation)
        {
            case UnBlock.Orientation.HORIZONTAL:
                if(FoundEmpty(new Vector3(Block.transform.position.x + distance, Block.transform.position.y, Block.transform.position.z)))
                {
                    directions.Add(UnBlock.Direction.RIGHT);
                }
                if (FoundEmpty(new Vector3(Block.transform.position.x - distance, Block.transform.position.y, Block.transform.position.z)))
                {
                    directions.Add(UnBlock.Direction.LEFT);
                }
                break;

            case UnBlock.Orientation.VERTICAL:
                if (FoundEmpty(new Vector3(Block.transform.position.x, Block.transform.position.y + distance, Block.transform.position.z)))
                {
                    directions.Add(UnBlock.Direction.TOP);
                }
                if (FoundEmpty(new Vector3(Block.transform.position.x , Block.transform.position.y - distance, Block.transform.position.z)))
                {
                    directions.Add(UnBlock.Direction.BOTTOM);
                }
                break;
        }
        return directions;
    }
    bool FoundEmpty(Vector3 CheckPosition)
    {
        foreach(GameObject e in empty)
        {
            //if (CheckPosition.x == e.transform.position.x && CheckPosition.y == e.transform.position.y)
            //    return true;
            if(CheckRange(CheckPosition.x - 4.5f, CheckPosition.x + 4.5f, e.transform.position.x) &&
                CheckRange(CheckPosition.y - 4.5f, CheckPosition.y + 4.5f, e.transform.position.y))
                return true;
        }
        return false;
    }
    bool CheckRange(float Min, float Max, float Value)
    {
        return Value >= Min && Value <= Max;
    }
}
