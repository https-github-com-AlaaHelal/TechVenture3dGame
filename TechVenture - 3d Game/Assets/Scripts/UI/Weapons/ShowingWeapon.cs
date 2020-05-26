using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ShowingWeapon : MonoBehaviour
{
    public Image WeaponImage;
    public GameObject Weapon;
    // Start is called before the first frame update
    void Start()
    {
        Weapon.SetActive(false);

    }

    public void ShowingWeaponWithPlayer()
    { 
    Weapon.SetActive(true);
        WeaponImage.enabled=false;

    }
}
