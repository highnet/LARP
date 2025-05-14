using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bumper : MonoBehaviour
{

    public float bumpCooldown;
    public float bumpTimer;
    public float punchScale;
    public float punchDuration;
    public float vibrato;
    public float elasticity;
    public float collisionForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (bumpTimer <= 0)
        {
            transform.DOPunchScale(Vector3.one * punchScale, punchDuration, 1,1);
            Rigidbody collidedRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            if (collidedRigidBody != null)
            {
                collidedRigidBody.AddForce((collision.gameObject.transform.position - this.transform.position).normalized * collisionForce);
            }
            bumpTimer = bumpCooldown;
        }
    }

    private void Update()
    {
        if (bumpTimer < 0)
        {
            bumpTimer = 0;
        } else
        {
            bumpTimer -= Time.unscaledDeltaTime;
        }
    }
}
