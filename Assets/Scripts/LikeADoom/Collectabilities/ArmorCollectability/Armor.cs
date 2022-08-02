using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] float ammoIncrease;
    [SerializeField] Collider collider;
    public void IncreaseArmor()
    {
        Debug.Log("Armor increased by " + ammoIncrease);
    }

    public void DisableArmorObject()
    {
        collider.enabled = false;
        gameObject.SetActive(false);
    }
}
