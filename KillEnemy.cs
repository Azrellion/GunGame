using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
