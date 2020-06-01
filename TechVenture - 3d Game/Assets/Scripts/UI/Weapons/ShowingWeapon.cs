using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ShowingWeapon : MonoBehaviour
{
    public Image WeaponImage;
    public GameObject WeaponCopy;

    void Start()
    {
        WeaponImage.enabled = false;
        WeaponCopy.SetActive(false);

    }

    public void ShowingWeaponWithPlayer()
    {
        if (WeaponImage.enabled == true)

        {
            WeaponCopy.SetActive(true);
            WeaponImage.enabled = false;
        }
    }
}
