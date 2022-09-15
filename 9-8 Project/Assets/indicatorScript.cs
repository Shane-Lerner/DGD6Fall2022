using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorScript : MonoBehaviour
{
    public Rigidbody rb;

    public float pivot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            pivot -= .1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pivot += .1f;
        }

        //rb.rotation.x = pivot;
    }
}
