using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnBlock : MonoBehaviour
{
    //public bool Selected = false;
    //public bool CanMove;
    //public GameObject BackGround;
    
    RectTransform RectTransform;
    public float Height;
    public GameObject EmptyGO;
    public float EmptyWidth;

    public Orientation orientation;
    public Type type;
    public Size size;
    public enum Orientation
    {
        HORIZONTAL, VERTICAL
    }
    public enum Type
    {
        RED, SILVER
    }
    public enum Size
    {
        TWO, THREE
    }

    public enum Direction
    {
        LEFT, RIGHT, TOP, BOTTOM
    }
    // Start is called before the first frame update
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();

        Height = RectTransform.rect.height;
        EmptyWidth = EmptyGO.GetComponent<RectTransform>().rect.height;        
    }
    
}
