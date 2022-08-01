using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] float armorIncrease;
    [SerializeField] Collider collider;
    public void IncreaseAmmo()
    {
        Debug.Log("Ammo increased by " + armorIncrease);
    }

    public void DisableAmmoObject()
    {
        collider.enabled = false;
        gameObject.SetActive(false);
    }
}
