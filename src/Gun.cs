using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bulletPrefab;
    public BasicButton basicButton;
    public float firingCooldown = 3f;
    public float firingTimer;

    private void Update()
    {
        if (firingTimer > 0)
        {
            firingTimer -= Time.deltaTime;

            if (firingTimer < 0)
            {
                firingTimer = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (firingTimer == 0 && basicButton.triggered)
        {
            FireGun();
        }
    }

    public void FireGun()
    {
        GameObject.Instantiate(bulletPrefab, this.transform.position - (Vector3.right * .5f),Quaternion.Euler(new Vector3(0f,-90f,0f)),this.transform);

        firingTimer = firingCooldown;
    }
}
