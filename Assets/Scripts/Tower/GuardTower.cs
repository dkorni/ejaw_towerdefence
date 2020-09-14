using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTower : TowerBase
{
    public List<Guard> Guards = new List<Guard>();

    public int GuardPrice;

    public const int MaxGuard = 4;

    [SerializeField] private GameObject _guardPrefab;

    [SerializeField] private Transform _guardSpawn;

    [SerializeField] private Transform _startGuardPoint;

    public override void Shoot(Enemy enemy)
    {
        foreach (var guard in Guards)
        {
            // whether guard have already attacked or enemy defends
            if(guard.IsAttack || enemy.IsAttacked)
                continue;

            guard.StartAttack(enemy);
            enemy.IsAttacked = true;
            guard.SetDestination(enemy.transform.position);
        }
    }

    public override void OnClick()
    {
        base.OnClick();

        if (Guards.Count < MaxGuard)
            UIManager.Instance.ShowRecrutButton(this);
    }

    public override void Destroy()
    {
        foreach (var guard in Guards)
        {
            Destroy(guard.gameObject);
        }
        base.Destroy();
    }

    public void CreateGuard()
    {
        var guardGo = Instantiate(_guardPrefab, _guardSpawn.position, Quaternion.identity);
        var guard = guardGo.GetComponent<Guard>();
        guard.StartGo(_startGuardPoint.position);
        guard.GuardTower = this;
        Guards.Add(guard);
    }
}
