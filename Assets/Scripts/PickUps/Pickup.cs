using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string itemName;
    Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public virtual void UseBonus()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !inventory.IsMaximum)
        {
            transform.SetParent(inventory.transform);
            inventory.AddItem(gameObject);
            gameObject.SetActive(false);
        }
    }
}
