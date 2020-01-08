using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyMovement : MonoBehaviour
{
    public PathCreator path;
    public float speed = 5.0f;
    float distNorm;

    bool reset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        distNorm += speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(distNorm);
        transform.rotation = path.path.GetRotationAtDistance(distNorm);


        if (reset)
        {
            distNorm = 0.0f;
            transform.position = path.path.GetPointAtDistance(distNorm);
            transform.rotation = path.path.GetRotationAtDistance(distNorm);
            reset = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
            reset = true;
    }
}
