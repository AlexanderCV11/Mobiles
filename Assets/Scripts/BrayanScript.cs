using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrayanScript : MonoBehaviour
{
    public GameObject projectile;
    public float projectileForce = 5f;
    public Transform startShotPoint;

    private void Update()
    {
        Vector2 projectilePos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimerDirection = mousePos - projectilePos;
        transform.right = aimerDirection;

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject newProjectile = Instantiate(projectile, startShotPoint.position, startShotPoint.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileForce;
    }
}
