using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcontroller : MonoBehaviour
{
    public float Maxspeed;
    public float RotatSpeed;
    public Animator character;

    public float mouseSensitivity = 4;
    float yaw;
    float pitch;
    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    public Vector3 currentRotation;
 //   public Vector2 pitchMinMax = new Vector2(-40, 85);


    // Start is called before the first frame update
    void Start()
    {
        character = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float walkforward = Input.GetAxis("Vertical") * Maxspeed * Time.deltaTime;
        transform.Translate(0, 0, walkforward);
       // float rotation = Input.GetAxis("Horizontal") * RotatSpeed * Time.deltaTime;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
       // pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
   //    pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
        if (walkforward > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Maxspeed = 12;
                character.SetFloat("speed", 3);
            }
            else
            {
                Maxspeed = 7;
                character.SetFloat("speed", 1);
            }
            

        }
       
        else if (walkforward < 0)
        {
            character.SetFloat("speed",2);

        }
        else
        {
            character.SetFloat("speed",0);

        }

       // transform.Rotate(script.GetComponent<camera>().currentRotation);

    }
}
