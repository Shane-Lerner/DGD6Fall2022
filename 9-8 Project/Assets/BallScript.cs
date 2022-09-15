using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public static GameObject ball;
    public Camera cam;
    public Rigidbody rb;

    public GameObject pointer;

    public Rigidbody pointerRB;
    // Start is called before the first frame update
    void Start()
    {
        ball = this.gameObject;
        rb.position = new Vector3(0, .101f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(rb.position.x, rb.position.y + 1.244f, rb.position.z + 3.395f);
        
        //Remove this section after figuring out movement
        Vector3 vel = new Vector3();
        if (Input.GetKey(KeyCode.UpArrow))
            vel.z -= .5f;
        else if (Input.GetKey(KeyCode.DownArrow))
            vel.z += .5f;
        if (Input.GetKey(KeyCode.RightArrow))
            vel.x -= .5f;
        else if (Input.GetKey(KeyCode.LeftArrow))
            vel.x += .5f;
        vel *= 10f;
        vel.y = rb.velocity.y;
        rb.velocity = vel;
        
            
    }
}
