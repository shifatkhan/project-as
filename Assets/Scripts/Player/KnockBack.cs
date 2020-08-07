﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author ShifatKhan
 */
[RequireComponent(typeof(Collider2D))]
public class KnockBack : MonoBehaviour
{
    public float thrust = 5f;
    public float knockTime = 0.2f;
    public float damage = 1;
    public bool hitStopEnabled = false;
    public float hitStopDuration = 0.1f;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            // Get Direction (by normalizing) and multiply the attack with thrust power.
            Vector2 direction = other.transform.position - transform.position;
            direction = direction.normalized * thrust;

            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<EntityNPC>().Damage(damage, direction, knockTime, hitStopEnabled, hitStopDuration); ;
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<Player>().Damage(damage, direction, knockTime, hitStopEnabled, hitStopDuration); ;
            }
        }
    }
}
