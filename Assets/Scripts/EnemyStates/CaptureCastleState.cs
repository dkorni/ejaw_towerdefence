using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureCastleState : IEnemyState
{
    public void Process(Enemy enemy)
    {
        var dist = Vector3.Distance(enemy.transform.position, enemy.TargetWaypoint.transform.position);

        if (dist < 0.5)
        {
            if (enemy.TargetWaypoint.Next != null)
            {
                // go to next waypoint
                enemy.TargetWaypoint = enemy.TargetWaypoint.Next;
                enemy.SetDestination(enemy.TargetWaypoint.transform.position);
            }
            else
            {
                // reached castle
                GameManager.Instance.TotalEnemyCount -= 1;

                GameManager.Instance.SetDamage(enemy.Damage, enemy);

                GameManager.Instance.DestroyGameObject(enemy.gameObject);
            }
        }
    }
}
