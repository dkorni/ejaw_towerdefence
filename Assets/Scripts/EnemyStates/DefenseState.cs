using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseState : IEnemyState
{
    public void Process(Enemy enemy)
    {
        var mobTarget = enemy.MobTarget;

        // switch to capture castle mode when mob target dead
        if (enemy.MobTarget == null)
        {
            enemy.StopAttack();
            enemy.IsAttacked = false;
            enemy.State = new CaptureCastleState();
            enemy.SetDestination(enemy.TargetWaypoint.transform.position);
            return;
        }

        if (!enemy.IsAttack && mobTarget != null)
        {
            enemy.StartAttack(mobTarget);
        }

        enemy.transform.LookAt(mobTarget.transform);

        enemy.SetDestination(mobTarget.transform.position);
    }
}
