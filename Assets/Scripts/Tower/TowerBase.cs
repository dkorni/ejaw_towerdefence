using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public float Range;

    public float Price;

    [SerializeField] protected float _shootInterval;

    [SerializeField] protected float _damage;

    private Coroutine _attackCoroutine;

    protected IEnumerator ProcessAttack()
    {
        var searchAttempts = 0;

        while (true)
        {
            // get possible enemy collliders in range
            var enemies = Physics.OverlapSphere(transform.position, Range, 1 << 8).Select(e => e.GetComponent<Enemy>())
                .ToList();

            // whether nobody in range - stop shooting
            if (enemies.Count == 0)
            {
                if (searchAttempts < 5)
                {
                    searchAttempts += 1;
                    yield return new WaitForSeconds(_shootInterval);
                }
                else
                {
                    StopCoroutine(_attackCoroutine);
                    _attackCoroutine = null;
                    break;
                }
            }

            // sort enemies
            enemies = enemies.OrderBy(e => Vector3.Distance(e.transform.position, GameManager.Instance.Castle.position))
                .ToList();

            // select closest enemy to castle
            var currentTarget = enemies.FirstOrDefault();


            if (currentTarget != null)
            {
                // make shoot
                Shoot(currentTarget);
            }

            yield return new WaitForSeconds(_shootInterval);
        }
    }

    public abstract void Shoot(Enemy enemy);

    public virtual void OnClick()
    {
        UIManager.Instance.ShowSellButton(this);
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        OnClick();
    }

    private void OnTriggerEnter(Collider col)
    {
        // whether enemy enter
        if (col.GetComponent<Enemy>())
        {
            if (_attackCoroutine == null)
            {
                // switch on attack mode
                _attackCoroutine = StartCoroutine(ProcessAttack());
            }
        }
    }

    private void Awake()
    {
        GetComponent<SphereCollider>().radius = Range * 10;
    }
}
