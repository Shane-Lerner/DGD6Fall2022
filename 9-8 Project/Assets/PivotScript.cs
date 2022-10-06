using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    public Rigidbody rb;
    Quaternion rotation = Quaternion.Euler(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = BallScript.ball.gameObject.transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(0,-.3f,0);
            rotation.y -= 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(0, .3f, 0);
            rotation.y += 2;
        }

        if (Input.GetKey(KeyCode.W) && rotation.x <= 80)
        {
            //transform.Rotate(.3f,0,0);
            rotation.x += 2;
        }

        if (Input.GetKey(KeyCode.S) && rotation.x >= 0)
        {
            //transform.Rotate(-.3f, 0, 0);
            rotation.x -= 2;
        }

        transform.rotation = Quaternion.Euler(rotation.x,rotation.y,0);
    }
}
