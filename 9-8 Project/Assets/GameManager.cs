using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.GM = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
