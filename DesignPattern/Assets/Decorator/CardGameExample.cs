using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameExample : MonoBehaviour
{
    void Start()
    {
        // Create a base card with a value of 10
        BattleCard baseCard = new(10);

        // Decorate the card with a DamageDecorator
        CardDecorator damageCard = new DamageDecorator(5);
        damageCard.Decorate(baseCard);

        // Decorate the card with a HealDecorator
        CardDecorator healCard = new HealDecorator(3);
        healCard.Decorate(damageCard);

        // Play the card
        int finalValue = healCard.Play();
        Debug.Log("Final card value: " + finalValue);
    }
}