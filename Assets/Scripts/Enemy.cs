using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mob
{
    public Waypoint TargetWaypoint;

    public IEnemyState State;

    public Mob MobTarget;

    public bool IsAttacked;

    [SerializeField]
    private int _minBonusGold;

    [SerializeField]
    private int _maxBonusGold;


    // Start is called before the first frame update
    void Start()
    {
        TargetWaypoint = GameManager.Instance.FirstWaypoint;
        StartMoving(TargetWaypoint.transform.position);
        State = new CaptureCastleState();
    }

    // Update is called once per frame
    void Update()
    {
        State.Process(this);
    }

    public override void SetDamage(float damage, object who)
    {
        base.SetDamage(damage, who);

        if (Health <= 0)
        {
            var bonusGold = Random.Range(_minBonusGold, _maxBonusGold);
            GameManager.Instance.AddGold(bonusGold);
            GameManager.Instance.DiedEnemyCount += 1;
            AudioManager.Instance.AddGold();
        }

        if (who is Mob guard)
        {
            State = new DefenseState();
            MobTarget = guard;
        }
    }
}
