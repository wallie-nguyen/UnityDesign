using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletHellManager : MonoBehaviour
{
    #region Setup
    [SerializeField]
    private int bulletCount = 100;

    [SerializeField]
    private float bulletSpeed = 10f;

    [SerializeField]
    private float bulletMaxDistance = 20f;

    [SerializeField]
    private LayerMask collisionMask;

    [SerializeField]
    private Transform bulletOrigin;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject impactEffectPrefab;
    #endregion

    ObjectPool<Bullet> bulletPool;
    BulletPatternGenerator patternGenerator;

    readonly List<Bullet> activeProjectiles = new List<Bullet>();
    readonly List<Bullet> bulletsToReturn = new List<Bullet>();

    private void Start()
    {
        patternGenerator = new BulletPatternGenerator(new RadialPattern());
        bulletPool = new ObjectPool<Bullet>(
            createFunc: () =>
            {
                GameObject bulletObject = Instantiate(bulletPrefab, bulletOrigin.transform, true);
                bulletObject.SetActive(false);
                return bulletObject.GetComponent<Bullet>();
            },
            actionOnGet: (bullet) => bullet.gameObject.SetActive(true),
            actionOnRelease: (bullet) => bullet.gameObject.SetActive(false),
            actionOnDestroy: (bullet) => Destroy(bullet.gameObject),
            collectionCheck: false,
            defaultCapacity: bulletCount,
            maxSize: bulletCount * 10
        );
    }

    private void LateUpdate()
    {
        foreach (Bullet bullet in bulletsToReturn)
        {
            bulletPool.Release(bullet);
        }
        bulletsToReturn.Clear();
    }

    public void SpawnBulletPattern()
    {
        BulletHellDTO[] newBullets = patternGenerator.GeneratePattern(bulletOrigin.position, bulletCount, bulletSpeed);
        foreach (BulletHellDTO projectile in newBullets)
        {
            Bullet newBullet = bulletPool.Get();
            newBullet.Initialize(projectile.Position, projectile.Direction, bulletMaxDistance);
            activeProjectiles.Add(newBullet);
        }
    }

    public void SetPattern(IBulletPattern bulletPattern) => patternGenerator.SetPattern(bulletPattern);
}

/// <summary>
/// DTO for a bullet in the bullet hell game.
/// </summary>
public class BulletHellDTO
{
    public Vector3 Position { get; private set; }
    public float Speed { get; private set; }
    public Vector3 Direction { get; private set; }

    public BulletHellDTO(Vector3 position, Vector3 direction, float speed)
    {
        Position = position;
        Direction = direction;
        Speed = speed;
    }
}

public interface IBulletPattern
{
    BulletHellDTO[] GeneratePattern(Vector3 origin, Vector3 forward, int bulletCount, float bulletSpeed);
}

public class RadialPattern : IBulletPattern
{

    public BulletHellDTO[] GeneratePattern(Vector3 origin, Vector3 forward, int bulletCount, float bulletSpeed)
    {
        throw new NotImplementedException();
    }
}

public class BulletPatternGenerator
{
    private IBulletPattern bulletPattern;

    public BulletPatternGenerator(IBulletPattern bulletPattern)
    {
        this.bulletPattern = bulletPattern;
    }

    public BulletHellDTO[] GeneratePattern(Vector3 position, int bulletCount, float bulletSpeed)
    {
        return bulletPattern.GeneratePattern(position, Vector3.forward, bulletCount, bulletSpeed);
    }

    public void SetPattern(IBulletPattern bulletPattern) => this.bulletPattern = bulletPattern;
}

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float maxDistance;
    public Vector3 startPosition;

    public void Initialize(Vector3 position, Vector3 direction, float maxDistance)
    {
        transform.position = position;
        startPosition = position;
        this.direction = direction;
        this.maxDistance = maxDistance;
    }

    public bool HasTravelMaxDistance()
    {
        float distanceTraveledSqr = (transform.position - startPosition).sqrMagnitude;
        return distanceTraveledSqr >= maxDistance * maxDistance;
    }
}