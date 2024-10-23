using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; }

    private Player(string name, int health)
    {
        Name = name;
        Health = health;
    }

    private void DoThing()
    {
        Debug.Log("I'm doing a thing");
    }

    /// <summary>
    /// Factory method with static method
    /// </summary>
    public static Player CreateAndDoThing(string name, int health)
    {
        Player newPLayer = new Player(name, health);
        newPLayer.DoThing();
        return newPLayer;
    }
}

/// If class have something like switch or if else to create object, it's a good idea to use factory pattern
/// Factory pattern is a creational pattern that uses factory methods to deal with the problem of creating objects without having to specify the exact class of object that will be created. <summary>
/// If class have something like switch or if else to create object, it's a good idea to use factory pattern

#region Factory Weapon 
public interface IWeapon
{
    void Attack();

    static IWeapon CreateDefaultWeapon()
    {
        return new Sword();
    }
}

public class Sword : IWeapon
{
    public void Attack()
    {
        Debug.Log("Sword Attack");
    }
}

public class Bow : IWeapon
{
    public void Attack()
    {
        Debug.Log("Bow Attack");
    }
}

public abstract class WeaponFactory : ScriptableObject
{
    public abstract IWeapon CreateWeapon();
}

[CreateAssetMenu(fileName = "SwordFactory", menuName = "Factory/SwordFactory")]
public class SwordFactory : WeaponFactory
{
    public override IWeapon CreateWeapon()
    {
        return new Sword();
    }
}

[CreateAssetMenu(fileName = "BowFactory", menuName = "Factory/BowFactory")]
public class BowFactory : WeaponFactory
{
    public override IWeapon CreateWeapon()
    {
        return new Bow();
    }
}

#endregion

#region Factory Shield
public interface IShield
{
    void Defend();

    static IShield CreateDefaultShield()
    {
        return new WoodenShield();
    }
}

public class WoodenShield : IShield
{
    public void Defend()
    {
        Debug.Log("Wooden Shield Defend");
    }
}

public abstract class ShieldFactory : ScriptableObject
{
    public abstract IShield CreateShield();
}

public class GenericShieldFactory : ShieldFactory
{
    public override IShield CreateShield()
    {
        return new WoodenShield();
    }
}
#endregion

public class EquipmentFactory : ScriptableObject
{
    public WeaponFactory weaponFactory;
    public ShieldFactory shieldFactory;

    public IWeapon CreateWeapon()
    {
        if (weaponFactory == null)
        {
            return IWeapon.CreateDefaultWeapon();
        }
        return weaponFactory.CreateWeapon();
    }

    public IShield CreateShield()
    {
        if (shieldFactory == null)
        {
            return IShield.CreateDefaultShield();
        }

        return shieldFactory.CreateShield();
    }
}

public class Knight : MonoBehaviour
{
    [SerializeField]
    private EquipmentFactory equipmentFactory;

    private IWeapon weapon;
    private IShield shield;

    private void Start()
    {
        weapon = equipmentFactory.CreateWeapon();
        shield = equipmentFactory.CreateShield();
    }

    public void Attack()
    {
        weapon.Attack();
    }
}