using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask WhatHit;

    public Transform BulletTrailPrefab;

    Collider2D col;

    float timeToFire = 0;
    Transform PointofFire;


    // Use this for initialization
    void Awake()
    {
        PointofFire = transform.FindChild("PointofFire");
        if (PointofFire == null)
        {
            Debug.LogError("No PointofFire?");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

    }

    void Shoot()
    {
        //Debug.Log("test");
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 PointofFirePosition = new Vector2(PointofFire.position.x, PointofFire.position.y);

        RaycastHit2D hit = Physics2D.Raycast(PointofFirePosition, mousePosition - PointofFirePosition, 100, WhatHit);

        Effect();

        Debug.DrawLine(PointofFirePosition, (mousePosition - PointofFirePosition) * 100, Color.cyan);

         if (hit.collider != null)
         {
             if(hit.collider.name == "Enemy")
             {
                 Destroy(hit.collider);
             }
        Debug.DrawLine(PointofFirePosition, hit.point, Color.red);
        Debug.Log("You hit " + hit.collider.name + " and did" + Damage + " damage.");
        }
    }

    void Effect()
    {
        Instantiate(BulletTrailPrefab, PointofFire.position, PointofFire.rotation);
    }
}
