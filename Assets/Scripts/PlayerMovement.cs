using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerMovement : MonoBehaviour
{

    public PathCreator path;
    public float speed = 5.0f;
    float distNorm;

    private bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            distNorm += speed * Time.deltaTime;
            transform.position = path.path.GetPointAtDistance(distNorm);
            transform.rotation = path.path.GetRotationAtDistance(distNorm);
        }


        if (reset)
        {
            distNorm = 0.0f;
            transform.position = path.path.GetPointAtDistance(distNorm);
            transform.rotation = path.path.GetRotationAtDistance(distNorm);
            reset = false;
            ChangeCamera.resetTrans = true;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
            reset = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.name == "TriggerCamera")
        {
        Debug.Log("TriggerCam");
            //Same position in Y & Z
            Vector3 nextCamPos = new Vector3(0.0f, 5.5f, -11.0f);
            ChangeCamera.ChangeCameraPos(nextCamPos, Quaternion.Euler(10.0f,0.0f,0.0f));
        }
    }


}
