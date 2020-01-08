using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public float transitionTime = 2.0f;

    private bool saveTransform = false;
    public static bool isChanging = false;
    public static bool resetTrans = false;
    
    public static Vector3 posDesired;
    private Vector3 initialPos;

    public static Quaternion quatDesired;
    private Quaternion initialRot;

    private float countTime = 0.0f;

    private Vector3 starterPos;
    private Quaternion starterRot;
    // Start is called before the first frame update
    void Start()
    {
        starterPos = transform.localPosition;
        starterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanging)
        {
            Debug.Log("Changing");
            if (!saveTransform)
            {
                initialPos = transform.localPosition;
                initialRot = transform.localRotation;
                saveTransform = true;
            }
            transform.localPosition = Vector3.Lerp(initialPos, posDesired, countTime);
            transform.localRotation = Quaternion.Lerp(initialRot, quatDesired, countTime);

            countTime += Time.deltaTime / transitionTime;

            if (posDesired.Equals(transform.localPosition) && quatDesired.Equals(transform.localRotation))
                ResetValues();
        }

        if(resetTrans)
        {
            transform.localPosition = starterPos;
            transform.localRotation = starterRot;
            resetTrans = false;
            ResetValues();
        }
    }

    private void ResetValues()
    {
        isChanging = false;
        saveTransform = false;
        countTime = 0.0f;
    }

    public static void ChangeCameraPos(Vector3 finalPos, Quaternion orientation)
    {
        posDesired = finalPos;
        quatDesired = orientation;      
        isChanging = true;
    }    
}
