using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int dmg;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerTakingDamage>())
        {
            other.gameObject.GetComponent<PlayerTakingDamage>().removeHealth(dmg);
        }

    }
}
