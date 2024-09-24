using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform pTraget;
    public Vector3 offset;
    //
    public float smoothTime;
    Vector3 vel = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(0, 0, -10f);
        smoothTime = 0.125f;
        var cameraTargetPos = pTraget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, cameraTargetPos, ref vel, smoothTime);
    }
}
