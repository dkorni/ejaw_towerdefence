using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour, IDamageSettable
{
    public float Health
    {
        get { return _health; }
    }

    public float Damage = 20;

    public bool IsAttack;

    [SerializeField] protected float _health = 100;


    [SerializeField] protected float _attackFrequency;

    [SerializeField] protected float _speed = 1.5f;

    protected NavMeshAgent _agent;

    protected Animator _animator;

    private Coroutine _attackCoroutine;

    // Start is called before the first frame update
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _agent.speed = _speed;
    }

    public virtual void SetDamage(float damage, object who)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDestination(Vector3 position)
    {
        _agent.SetDestination(position);
    }

    public virtual void StartMoving(Vector3 target)
    {
        SetDestination(target);
        _animator.SetBool("Move", true);
    }

    public virtual void StopMoving()
    {
        _animator.SetBool("Move", false);
    }

    public void StartAttack(IDamageSettable target)
    {
        IsAttack = true;

        if(_attackCoroutine != null)
            StopAttack();

       _attackCoroutine = StartCoroutine(Attack(target));
    }

    public void StopAttack()
    {
        StopCoroutine(_attackCoroutine);
    }

    protected virtual IEnumerator Attack(IDamageSettable target)
    {
        while (true)
        {
            _animator.SetTrigger("Attack");
            
            yield return new WaitForSeconds(_attackFrequency);

            target.SetDamage(Damage, this);
        }
    }
}
