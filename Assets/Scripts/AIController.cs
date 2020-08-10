﻿using RPG.Combat;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        Fighter fighter;
        Health health;
        GameObject player;
        private void Start()
        {

            health = GetComponent<Health>();
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
        }
        private void Update()
        {
            if (health.IsDead()) return;
            if (InAttackRangeOfPlayer(player) && fighter.CanAttack(player))
            {
                fighter.Attack(player);
                
            }
            else
            {
                fighter.Cancel();
            }

        }

        private bool InAttackRangeOfPlayer(GameObject player)
        {

            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }
    }
}
