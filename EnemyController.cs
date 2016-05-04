using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float walkingspeed = 0.5f;
    private bool walkingLeft = true;


	// Use this for initialization
	void Start () {
        walkingLeft = (Random.Range(0, 2) == 1);
        UpdateDirection();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(walkingLeft)
        {
            transform.Translate(new Vector3(walkingspeed * Time.deltaTime, 0.0f, 0.0f));
        }
        else
        {
            transform.Translate(new Vector3((walkingspeed * -1.0f) * Time.deltaTime, 0.0f, 0.0f));
        }
	}

    public void switchDirection()
    {
        walkingLeft = !walkingLeft;
        UpdateDirection();
    }

   void UpdateDirection()
   {
       Vector3 localScale = transform.localScale;

       if(walkingLeft)
   {
       if(localScale.x > 0.0f)
       {
           localScale.x = localScale.x * -1.0f;
           transform.localScale = localScale;
       }
   }
       else
       {
           if(localScale.x < 0.0f)
           {
               localScale.x = localScale.x * -1.0f;
               transform.localScale = localScale;
           }
       }

   }
}
