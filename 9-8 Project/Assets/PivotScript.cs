using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(0,-.3f,0);
            rotation.y -= .3f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(0, .3f, 0);
            rotation.y += .3f;
        }

        if (Input.GetKey(KeyCode.W) && transform.rotation.x <= 80)
        {
            //transform.Rotate(.3f,0,0);
            rotation.x += .3f;
        }

        if (Input.GetKey(KeyCode.S) && transform.rotation.x >= 0)
        {
            //transform.Rotate(-.3f, 0, 0);
            rotation.x -= .3f;
        }

        transform.rotation = rotation;
    }
}
