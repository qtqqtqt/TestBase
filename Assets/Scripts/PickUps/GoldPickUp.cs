using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : Pickup
{
    [SerializeField] int goldAmount = 10;
    GoldHandler goldBank;

    private void Start()
    {
        goldBank = FindObjectOfType<GoldHandler>();
    }

    public override void UseBonus()
    {
        goldBank.AddGold(goldAmount);
    }
}
