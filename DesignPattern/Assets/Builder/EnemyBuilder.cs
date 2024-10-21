using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// https://www.youtube.com/watch?v=Wud_ooJKdzU&t=126s
public class Enemy : MonoBehaviour
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public float Speed { get; private set; }
    public bool IsBoss { get; private set; }

    public class Builder
    {
        private string name;
        private int health;
        private int damage;
        private float speed;
        bool isBoss;

        public Builder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public Builder SetHealth(int health)
        {
            this.health = health;
            return this;
        }

        public Builder SetDamage(int damage)
        {
            this.damage = damage;
            return this;
        }

        public Builder SetSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public Builder SetIsBoss(bool isBoss)
        {
            this.isBoss = isBoss;
            return this;
        }

        public Enemy Build()
        {
            var Enemy = new GameObject("Enemy").AddComponent<Enemy>();
            Enemy.Name = name;
            Enemy.Health = health;
            Enemy.Damage = damage;
            Enemy.Speed = speed;
            Enemy.IsBoss = isBoss;

            return Enemy;
        }
    }
}

public class Example : MonoBehaviour
{
    void Start()
    {
        var enemy = new Enemy.Builder()
            .SetName("Goblin")
            .Build();
    }
}