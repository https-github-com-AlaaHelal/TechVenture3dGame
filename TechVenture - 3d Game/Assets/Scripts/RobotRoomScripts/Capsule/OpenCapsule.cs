using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCapsule : MonoBehaviour
{
    Animator Capsuleanimator;
    public GameObject [] Capsule;
    public Transform player;
    public float Distance = 7;
    bool open;

    bool AlarmIsActive;
 
    public AudioSource Sound;
  

 
    void Start()
    {

         StartCoroutine(StartAlarm());
    }

    public void Update() {
        float distance = Vector3.Distance(player.position, this.transform.position);

        if (distance <= Distance)
        {
           // AlarmIsActive = true;
            for (int i = 0; i < Capsule.Length; i++)
            {
                Capsuleanimator = Capsule[i].GetComponent<Animator>();

                if (open == false)
                {
                    Capsuleanimator.SetBool("open", true);
                    Capsuleanimator.SetFloat("speed", 15);
                 
                }

            }
            open = true;
            if (AlarmIsActive)
            {
                // StartCoroutine(StartAlarm());

                playAlarm();
            }


        }

    }

    void playAlarm()
    {
        Sound.Play();
        AlarmIsActive = false;
    }

    public void StopAlarm()
    {
        Sound.enabled = false;
    }


    IEnumerator StartAlarm()
    {
        yield return new WaitForSeconds(1.5f);
     
        AlarmIsActive = true;

        
    }
}
