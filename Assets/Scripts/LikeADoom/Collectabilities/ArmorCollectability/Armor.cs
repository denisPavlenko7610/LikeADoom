using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] float ammoIncrease;
    [SerializeField] Collider collider;
    public void ArmorIncreasing()
    {
        Debug.Log("Armor increased by " + ammoIncrease);
        collider.enabled = false;
        gameObject.SetActive(false);
    }
}
