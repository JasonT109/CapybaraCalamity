﻿using UnityEngine;
using System.Collections;

public class AbilityPickup : MonoBehaviour
{
    public abilityHandler.Abilities Ability;
    public int Count;
    public GameObject ParticleEffect;

    public void SpawnParticleEffect()
    {
        GameObject ParticleClone = Instantiate(ParticleEffect, transform.position, Quaternion.identity) as GameObject;
    }
}
