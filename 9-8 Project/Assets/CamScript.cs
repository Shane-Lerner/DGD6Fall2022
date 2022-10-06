using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    //Quaternion rotation = Quaternion.Euler(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = BallScript.ball.gameObject.transform.position;
        
        Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if ((rotation.x <= 85 && rotation.x >= 0) || (rotation.x <= 360 && rotation.x >= 300) || (rotation.x <= 0 && rotation.x >= -85))
            rotation.x += mouseY;
        if (rotation.x > 85 && rotation.x < 95)
            rotation.x = 85;
        if (rotation.x < 300 && rotation.x > 290)
            rotation.x = 300;
        rotation.y += mouseX;
        transform.rotation = Quaternion.Euler(rotation);

    }
}
