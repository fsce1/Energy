using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))Camera.main.transform.position += new Vector3(0.05f,0, 0.05f);
        if (Input.GetKey(KeyCode.S)) Camera.main.transform.position += new Vector3(-0.05f, 0, -0.05f);
        if (Input.GetKey(KeyCode.A)) Camera.main.transform.position += new Vector3(-0.05f, 0, 0.05f);
        if (Input.GetKey(KeyCode.D)) Camera.main.transform.position += new Vector3(0.05f, 0, -0.05f);

    }
}
