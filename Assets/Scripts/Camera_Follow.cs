using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    [Range(1,10)]
    public float smoothFactor;


    private void Awake()
    {
        smoothFactor = 6.0f;
        offset = new Vector3(15.0f, -1.0f, -1.0f);
    }

    // Update is called once per frame
    void FixedUpdate() {
        Follow();
    }



    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
