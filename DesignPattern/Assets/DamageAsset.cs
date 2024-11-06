using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageAsset", menuName = "DamageAsset")]
public class DamageAsset : ScriptableObject, IDamageable
{
    public void TakeDamage(int damage)
    {
        Debug.Log("Damage asset taken: " + damage);
    }
}
