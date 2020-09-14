using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : TowerBase
{
    public Transform Cannon;

    public Transform BulletSpawn;

    public GameObject Bullet;

    public float Force;

    public override void Shoot(Enemy enemy)
    {
        Debug.Log($"Shoot at enemy {enemy.name}");

        var direction = enemy.transform.position - Cannon.transform.position;

        var lookDirection = direction;

        lookDirection.y = 0;

        Cannon.rotation = Quaternion.LookRotation(lookDirection);

        // shoot bullet
        var bulletGO = Instantiate(Bullet, BulletSpawn.position, Quaternion.identity);

        bulletGO.GetComponent<Rigidbody>().AddForce(direction*Force, ForceMode.Impulse);

        var bullet = bulletGO.GetComponent<Bullet>();

        bullet.Damage = _damage;
    }
}
