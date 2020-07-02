using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddLaserToArm : MonoBehaviour
{
    public GameObject OFFPanel;
    public GameObject OnPanel;
    public GameObject LaserArm;
    bool LazerArm;
    public GameObject Inventory;
    private Inventory inventory;
    public Transform player;
    public float Distance = 9;
    public LineRenderer line;
    public Transform firepoint;
    public Transform target;
    public ParticleSystem particle;
    public Light Glow;
    public Light FirePoinGlow;
    public GameObject ScreenPuzzle;
    public GameObject breakableGalss;

    public Animator playeranimatore;
    public GameObject Stand;
    bool StartNextPuzzle;


    public GameObject RestGlass;
    public GameObject FunctionInfoBall;






    void Start()
    {

        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        LaserArm.SetActive(false);
        line.SetPosition(0, firepoint.position);
        line.SetPosition(1, target.position);
        line.enabled = false;
        Glow.enabled = false;
        FirePoinGlow.enabled = false;
        particle.Stop();
        OnPanel.SetActive(false);
        ScreenPuzzle.SetActive(false);
        RestGlass.SetActive(false);
        FunctionInfoBall.SetActive(false);


    }
    public void Update()
    {


        float distance = Vector3.Distance(player.position, transform.position);

        InventorySlot slot = inventory.SelectedSlot;

        // Debug.Log(slot);
        if (slot != null && slot.item != null)
        {

            if (slot.item.name.ToString() == "LaserArm" && distance <= Distance)

            {
                // Debug.Log(distance);
                LaserArm.SetActive(true);
               // inventory.Remove(slot.item);
                StartCoroutine(UseLaser());

            }
        }

    }


        public void TurnOnScreenPuzzle()

        {
           if( StartNextPuzzle == true)

            ScreenPuzzle.SetActive(true);


        StartNextPuzzle = false;
        }




        IEnumerator UseLaser()
        {
            yield return new WaitForSeconds(1f);

            line.enabled = true;
            FirePoinGlow.enabled = true;
            particle.Play();
            Glow.enabled = true;

            particle.Play();
         

            particle.transform.position = target.transform.position;
            Glow.transform.position = target.transform.position;

            yield return new WaitForSeconds(3f);
            line.enabled = false;
            Glow.enabled = false;
            FirePoinGlow.enabled = false;

            particle.Stop();
            OFFPanel.SetActive(false);
            OnPanel.SetActive(true);


        // FindObjectOfType<breakGlass>().Explode();
            breakableGalss.SetActive(true);
            RestGlass.SetActive(true);
            FunctionInfoBall.SetActive(true);
            StartNextPuzzle = true;



        }

    }
