using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
}

public class Examples : MonoBehaviour
{
    public InterfaceReference<IDamageable> damageable;

    [RequireInterface(typeof(IDamageable))]
    public MonoBehaviour damageableComponent;

    [RequireInterface(typeof(IDamageable))]
    public ScriptableObject damageableAsset;

    public InterfaceReference<IDamageable, ScriptableObject> dmgSO;

    public InterfaceReference<IDamageable, MonoBehaviour> dmgMB;

    void Start()
    {
        damageable.Value.TakeDamage(10);


    }
}
