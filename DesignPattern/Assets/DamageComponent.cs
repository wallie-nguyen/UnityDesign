using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        Debug.Log("Damage component taken: " + damage);
    }
}
