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
    bool neartoscreen;
    public Animator playeranimatore;
    public GameObject Screen;
  
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
        ScreenPuzzle.SetActive(false);
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
                inventory.Remove(slot.item);
                StartCoroutine(UseLaser());

            }
        }


        //float distancefromScreen = Vector3.Distance(player.position, Screen.transform.position);
        //Debug.Log(distancefromScreen);

        //if (neartoscreen == true && distancefromScreen < Distance)
        //{
        //    //playeranimatore.gameObject.SetActive(false);
        //  //  Camera.main.transform.rotation = cameraview.rotation;

        //}


        //if (neartoscreen == true && distancefromScreen > Distance)
        //{
        //  //  playeranimatore.gameObject.SetActive(true);

        //}







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
           

            FindObjectOfType<breakGlass>().Explode();
            RestGlass.SetActive(true);
             ScreenPuzzle.SetActive(true);
            FunctionInfoBall.SetActive(true);




        }

    }
}