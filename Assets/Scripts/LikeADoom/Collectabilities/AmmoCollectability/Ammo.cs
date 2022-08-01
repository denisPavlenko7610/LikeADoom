using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] float armorIncrease;
    [SerializeField] Collider collider;
    public void AmmoIncreasing()
    {
        Debug.Log("Ammo increased by " + armorIncrease);
        collider.enabled = false;
        gameObject.SetActive(false);
    }
}
