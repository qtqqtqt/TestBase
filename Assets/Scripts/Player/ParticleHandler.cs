using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    ParticleSystem attackParticles;

    private void OnEnable()
    {
        attackParticles = GetComponent<ParticleSystem>();
        var emissionModule = attackParticles.emission;
        emissionModule.rateOverTime = GetComponentInParent<PlayerAttack>().AttackRate;
    }
}
