using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Inventory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemsText;
    [SerializeField] TextMeshProUGUI usedItemsText;
    [SerializeField] int maximumItems;

    List<GameObject> inventoryItems = new List<GameObject>();

    bool isMaximum = false;
    public bool IsMaximum { get { return isMaximum; } }

    Dictionary<string, int> usedBonuses = new Dictionary<string, int>();
    CollisionHandler playerCollision;

    private void Start()
    {
        playerCollision = FindObjectOfType<CollisionHandler>();
        ClearItemsList();
    }

    private void Update()
    {
        if (playerCollision.InBase && inventoryItems.Count != 0)
        {
            EmptyInventory();
        }

        if(inventoryItems.Count == maximumItems)
        {
            isMaximum = true;
        }
    }

    public void AddItem(GameObject item)
    {
        if (!isMaximum)
        {
            inventoryItems.Add(item);
            itemsText.text += "\n" + item.GetComponent<Pickup>().itemName;
        }
    }

    private void EmptyInventory()
    {
        foreach (GameObject item in inventoryItems)
        {
            Pickup pickedUpItem = item.GetComponent<Pickup>();
            pickedUpItem.UseBonus();
            UpdateUsedBonuses(pickedUpItem.itemName);
            Destroy(item);
        }
        ClearItemsList();
        
    }

    private void ClearItemsList()
    {
        inventoryItems.Clear();
        itemsText.text = "Items: ";
    }

    private void UpdateUsedBonuses(string bonusName)
    {
        if (usedBonuses.ContainsKey(bonusName))
        {
            usedBonuses[bonusName]++;
        }
        else
        {
            usedBonuses.Add(bonusName, 1);
        }
        usedItemsText.text = "Used: ";
        foreach (KeyValuePair<string,int> bonuses in usedBonuses)
        {
            usedItemsText.text += bonuses.Key + " x " + bonuses.Value;
        }

    }
}
