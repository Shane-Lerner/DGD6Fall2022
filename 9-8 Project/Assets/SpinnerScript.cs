using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpinnerScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion rot = Quaternion.Euler(rb.rotation.x, rb.rotation.y, rb.rotation.z);
        rot.z += 1f;
        rb.rotation = rot;
        
    }
}
