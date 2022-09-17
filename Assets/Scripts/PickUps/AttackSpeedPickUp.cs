using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedPickUp : Pickup
{
    PlayerAttack player;

    private void Start()
    {
        player = FindObjectOfType<PlayerAttack>();
    }

    public override void UseBonus()
    {
        player.AttackRate++;
    }
}
