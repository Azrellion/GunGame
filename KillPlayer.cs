using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
