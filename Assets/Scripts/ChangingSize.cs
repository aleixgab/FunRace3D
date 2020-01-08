using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSize : MonoBehaviour
{
    public float speed;

    public float minSize;
    public float maxSize;

    bool growing = true;
    // Update is called once per frame
    void Update()
    {
        Vector3 nextScale = Vector3.one;
        if (growing)
        {
            nextScale.y = transform.localScale.y + speed * Time.deltaTime;
        
            if (transform.localScale.y >= maxSize)
                growing = false;
        }
        else
        {
            nextScale.y = transform.localScale.y - speed * Time.deltaTime;

            if (transform.localScale.y <= minSize)
                growing = true;
        }
        
        transform.localScale = nextScale;
    }
}
