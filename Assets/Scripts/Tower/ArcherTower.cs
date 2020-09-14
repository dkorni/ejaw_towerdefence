using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : TowerBase
{
    public Transform[] _arrowSpawns;

    public GameObject Arrow;

    public float Force;

    public override void Shoot(Enemy enemy)
    {
        Debug.Log($"Shoot at enemy {enemy.name}");

        foreach (var arrowSpawn in _arrowSpawns)
        {
            var direction = enemy.transform.position - transform.TransformPoint(arrowSpawn.position);

            var lookDirection = direction;

            lookDirection.y = 0;

            // shoot bullet
            var bulletGO = Instantiate(Arrow, arrowSpawn.position, Quaternion.LookRotation(lookDirection));

            bulletGO.GetComponent<Rigidbody>().AddForce(direction * Force, ForceMode.Impulse);

            var bullet = bulletGO.GetComponent<Bullet>();

            bullet.Damage = _damage;
        }
    }
}
