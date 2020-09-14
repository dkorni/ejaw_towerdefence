using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage { get; set; }

    public GameObject ExplosiveParticle;

    private const float TimeToDestroyParticle = 3;

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.transform.name);
        var victim = col.transform.GetComponent<IDamageSettable>();
        if (victim != null)
        {
            victim.SetDamage(Damage, this);
        }

        if (ExplosiveParticle != null)
        {
            var particle = Instantiate(ExplosiveParticle, transform.position, Quaternion.identity);
            Destroy(particle, TimeToDestroyParticle);
        }

        Destroy(gameObject);
    }
}
