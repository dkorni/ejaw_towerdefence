using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Mob
{
    public GuardTower GuardTower;

    private bool _isMoving;

    private Vector3 _currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving && Vector3.Distance(transform.position, _currentTarget) < 1)
        {
            StopMoving();
            _isMoving = false;
        }
    }

    public void StartGo(Vector3 target)
    {
        _currentTarget = target;
        _isMoving = true;
        StartMoving(target);
    }

    public override void SetDamage(float damage, object who)
    {
        _health -= damage;
        if (_health <= 0)
        {
            GuardTower.Guards.Remove(this);
            Destroy(gameObject);
        }
    }

    protected override IEnumerator Attack(IDamageSettable target)
    {
        while (true)
        {
            _animator.SetTrigger("Attack");

            yield return new WaitForSeconds(_attackFrequency);

            target.SetDamage(Damage, this);

            if (target.Health <= 0)
            {
                StopAttack();
                IsAttack = false;
            }
        }
    }
}
