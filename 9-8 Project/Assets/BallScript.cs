using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public static GameObject ball;
    public Camera cam;
    public Rigidbody rb;

    public GameObject pivot;
    public GameObject indic;

    public Quaternion direction;
    public int power = 0;
    public int hitTimer = 0;
    public bool onGround;
    public int debugTime = 100;
    public ParticleSystem ps;
    
    public Mode mode = Mode.Putting;
    // Start is called before the first frame update
    void Start()
    {
        ball = this.gameObject;
        rb.position = new Vector3(0, .101f, 0);
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Mode: " + mode + "     Velocity: " + (rb.velocity.x + rb.velocity.z) + ", " + rb.velocity.y + "     Power: " + power);
        if (mode == Mode.Putting)
            indic.gameObject.SetActive(true);
        else if (mode == Mode.Hit)
            indic.gameObject.SetActive(false);
        
        //Hitting
        switch (mode)
        {
            case Mode.Putting:
            {
                Control();
                break; 
            }
            case Mode.Hit:
            {
                Hit();
                break;
            }
        }
        
        if (rb.position.y <= -1)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.position = new Vector3(GameManager.GM.respawn.x, GameManager.GM.respawn.y + 5, GameManager.GM.respawn.z);
        }
    }

    void Control()
    {
        if (Input.GetKey(KeyCode.Space) && power < 300)
        {
            power++;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(pivot.transform.forward * -power * 10);
            power = 0;
            hitTimer = 5;
            mode = Mode.Hit;
        }
        //Debug.Log(power);
    }

    void Hit()
    {
        if (hitTimer > 0)
            hitTimer--;
        if (rb.velocity.x + rb.velocity.z <= .05f && (rb.velocity.y <= .01f && rb.velocity.y >= -.01f) && onGround)
        {
            rb.velocity = new Vector3(0, 0, 0);
            if (hitTimer == 0)
                mode = Mode.Putting;
        }

        if (!onGround && rb.velocity.x + rb.velocity.z <= .05f && (rb.velocity.y <= .01f && rb.velocity.y >= -.01f))
            debugTime--;
        if (debugTime <= 0)
        {
            debugTime = 100;
            mode = Mode.Putting;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("On");
        onGround = true;
    }

    private void OnCollisionExit(Collision other)
    {
        //Debug.Log("Off");
        onGround = false;
    }
}

public enum Mode
{
    Putting = 0,
    Hit = 1,
}
