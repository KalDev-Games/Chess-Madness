using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rot = -Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime;
        
        transform.Rotate(new Vector3(0,rot,0));

        
        
    }
}
