﻿/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int damageAmount;

    private void OnTriggerEnter2D(Collider2D collider) {
        Player player = collider.GetComponent<Player>();
        if (player != null) {
            // We hit the Player
            Vector3 knockbackDir = (player.GetPosition() - transform.position).normalized;
            player.DamageKnockback(knockbackDir, 5f, damageAmount);
        }
    }
}
