using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldHandler : MonoBehaviour
{
    [SerializeField] int gold = 100;
    [SerializeField] TextMeshProUGUI goldText;

    Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        UpdateGoldUI();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        goldText.text = "Gold: " + gold.ToString();
    }
}
