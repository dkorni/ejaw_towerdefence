using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagTower : TowerBase
{
    [SerializeField] private GameObject _fireBall;

    [SerializeField] private Transform _spawn;

    [SerializeField] private float _force;

    [SerializeField] private Transform _mag;

    [SerializeField] private float _attackAnimationDelay = 1.3f;

    [SerializeField]
    private Animator _animator;

    public override void Shoot(Enemy enemy)
    {
        Debug.Log($"Shoot at enemy {enemy.name}");

        _animator.SetTrigger("Attack");

        StartCoroutine(ShootWithDelay(enemy));
    }

    private IEnumerator ShootWithDelay(Enemy enemy)
    {
        yield return new WaitForSeconds(_attackAnimationDelay);

        var direction = enemy.transform.position - _mag.position;

        var lookDirection = direction;

        lookDirection.y = 0;

        _mag.rotation = Quaternion.LookRotation(lookDirection);

        // shoot bullet
        var fireBallGO = Instantiate(_fireBall, _spawn.position, Quaternion.identity);

        fireBallGO.GetComponent<Rigidbody>().AddForce(direction * _force, ForceMode.Impulse);

        var bullet = fireBallGO.GetComponent<Bullet>();

        bullet.Damage = _damage;

        AudioManager.Instance.Fireball();
    }
}
