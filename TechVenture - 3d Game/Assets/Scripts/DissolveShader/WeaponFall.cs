using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFall : MonoBehaviour
{
    public GameObject OrbShield;

    private dissolveBehaviour behaviour;
    private Rigidbody WeaponRb;

    // Start is called before the first frame update
    void Start()
    {
        behaviour = OrbShield.GetComponent<dissolveBehaviour>();
        WeaponRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (behaviour.Fall)
        {
            Destroy(OrbShield);
            WeaponRb.useGravity = true;
        }
    }
}
