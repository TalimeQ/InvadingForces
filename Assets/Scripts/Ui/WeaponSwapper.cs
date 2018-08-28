using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSwapper :  MonoBehaviour ,IWeaponSwapListener {

    [SerializeField] Sprite laserImage;
    [SerializeField] Sprite normalWeaponImage;
    Image weaponSwapperRef;
    void Start()
    {
        weaponSwapperRef = GetComponent<Image>();
    }
    void IWeaponSwapListener.OnWeaponSwap(bool isLaser)
    {
        if(isLaser)
        {
            weaponSwapperRef.sprite = laserImage;
        }
        else
        {
            weaponSwapperRef.sprite = normalWeaponImage;
        }
    }

    // Use this for initialization

}
