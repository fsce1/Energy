using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public float moveSpeed = 0.025f;
    public float scrollSpeed = 1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))Camera.main.transform.position += new Vector3(moveSpeed, 0, moveSpeed);
        if (Input.GetKey(KeyCode.S)) Camera.main.transform.position += new Vector3(-moveSpeed, 0, -moveSpeed);
        if (Input.GetKey(KeyCode.A)) Camera.main.transform.position += new Vector3(-moveSpeed, 0, moveSpeed);
        if (Input.GetKey(KeyCode.D)) Camera.main.transform.position += new Vector3(moveSpeed, 0, -moveSpeed);

        if (Input.mouseScrollDelta.y > 0) Camera.main.orthographicSize -= scrollSpeed;
        if (Input.mouseScrollDelta.y < 0) Camera.main.orthographicSize += scrollSpeed;
        Camera.main.orthographicSize  = Mathf.Clamp(Camera.main.orthographicSize, 1, 10);
    }
}
