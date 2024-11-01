using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellStrategy : ScriptableObject
{
    public abstract void CastSpell(Transform origin);
}

public class ShieldSpell : SpellStrategy
{
    public GameObject shieldPrefab;

    public override void CastSpell(Transform origin)
    {
        Instantiate(shieldPrefab, origin.position, origin.rotation);
    }
}

public class HeroStrategy : MonoBehaviour
{
    public SpellStrategy spellStrategy;

    public void CastSpell()
    {
        spellStrategy.CastSpell(transform);
    }
}