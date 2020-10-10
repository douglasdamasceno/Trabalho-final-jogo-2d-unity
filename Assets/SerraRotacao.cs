using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerraRotacao : MonoBehaviour
{
    // Start is called before the first frame update
    float vel = 0.05f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * vel, Space.World);
       
    }
}
