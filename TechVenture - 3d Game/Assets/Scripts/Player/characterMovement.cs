using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float WalkSpeed;
    public float RotatSpeed;
    Animator anim;
    public GameObject gun;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        gun.gameObject.SetActive(false);
        ball.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()

    {   
        
        
        
        if (anim == null) return;

        float Y = Input.GetAxis("Vertical");
        float X = Input.GetAxis("Horizontal");
        move(X, Y);



















       
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    anim.SetBool("pick", true);
        //    anim.SetBool("pickupmid", true);
        //    WalkSpeed = 0;
        //}

        //if (Input.GetKeyUp(KeyCode.Z))
        //{
        //    anim.SetBool("pickupmid", false);
        //    anim.SetBool("pick", false);

        //    WalkSpeed = 2;
        //    gun.SetActive(true);
        //}

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    anim.SetBool("pickuplow", true);
        //    anim.SetBool("pick", true);

        //    WalkSpeed = 0;
        //    gun.SetActive(false);
        //    ball.SetActive(true);



        //}
        //if (Input.GetKeyUp(KeyCode.X))
        //{
        //    anim.SetBool("pick", false);

        //    anim.SetBool("pickuplow", false);
        //    WalkSpeed = 2;
        //}
        //if (Input.GetKeyUp(KeyCode.N))
        //{
        //    gun.SetActive(true);

        //}
        //if (Input.GetKeyUp(KeyCode.M))
        //{
        //    gun.SetActive(false);

        //}


    }
   void move(float X, float Y)
    {
       // anim.SetFloat("VX", X);
        anim.SetFloat("Y", Y);

        transform.position += Vector3.forward *  Y *WalkSpeed * Time.deltaTime;
     //   transform.Rotate ( 0, X *RotatSpeed * Time.deltaTime,0);

    }
}
