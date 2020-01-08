using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    bool movingCamera;
    Vector3 posOffset;
    Quaternion rotOffset;
    // Start is called before the first frame update
    void Start()
    {
        movingCamera = false;
        posOffset = transform.position - player.position;
        rotOffset = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingCamera)
            transform.position = player.position + posOffset;
        else
        {
            if (Input.touchCount > 0)
            {
                
            }
        }
        
        
        transform.rotation = player.rotation * rotOffset;


    }
}
