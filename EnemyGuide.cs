using UnityEngine;
using System.Collections;

public class EnemyGuide : MonoBehaviour {

    public EnemyController enemyobject = null;

    void OnTriggerExit2D(Collider2D otherobj)
    {
        if(otherobj.tag == "Platform")
        {
            enemyobject.switchDirection();
        }
    }
}
