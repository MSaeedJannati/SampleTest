using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Bullet
{
    public override void ImpactEffect(Vector3 contactPos)
    {

        Collider[] cols = Physics.OverlapSphere(contactPos, 3f);

        for (int i = 0; i < cols.Length; i++)
        {
            var rb = cols[i].gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(10.0f, contactPos, 1.7f, 1f, ForceMode.Impulse);
            }
        }
        disableBullet();
    }
}
