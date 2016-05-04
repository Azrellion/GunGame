using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherobj)
    {
        if(otherobj.tag == "Player")
        {
            Application.LoadLevel("OuterDawn");
        }
    }
}
