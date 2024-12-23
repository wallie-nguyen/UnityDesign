using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAssetBase : ScriptableObject, IDamageable
{
    public void TakeDamage(int damage)
    {
        Debug.Log("Damage asset taken: " + damage);
    }
}

[CreateAssetMenu(fileName = "DamageAsset", menuName = "DamageAsset")]
public class DamageAsset : DamageAssetBase
{
}
