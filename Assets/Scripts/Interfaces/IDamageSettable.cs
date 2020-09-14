using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageSettable
{
    float Health { get; }

    void SetDamage(float damage, object who);
}
