using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    public int Play();
}

public class BattleCard : ICard
{
    readonly int value;

    public BattleCard(int value)
    {
        this.value = value;
    }

    public int Play()
    {
        Debug.Log("Play BattleCard");
        return value;
    }
}

public abstract class CardDecorator : ICard
{
    protected ICard card;
    protected readonly int value;

    protected CardDecorator(int value)
    {
        this.value = value;
    }

    public void Decorate(ICard card)
    {
        if (this.card is CardDecorator decorator)
        {
            decorator.Decorate(card);
        }
        else
        {
            this.card = card;
        }
    }

    public virtual int Play()
    {
        if (card == null)
        {
            return value;
        }
        return card.Play() + value;
    }
}

public class DamageDecorator : CardDecorator
{
    public DamageDecorator(int value) : base(value)
    {
    }

    public override int Play()
    {
        Debug.Log("Play DamageDecorator");
        return base.Play();
    }
}

public class HealDecorator : CardDecorator
{
    public HealDecorator(int value) : base(value) { }

    public override int Play()
    {
        Debug.Log("Play HealDecorator");
        HealPlayer();
        return base.Play();
    }

    private void HealPlayer()
    {
        Debug.Log("Heal player");
    }
}