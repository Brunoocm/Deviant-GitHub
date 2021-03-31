using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform pai;
    public Transform filho;
    public float Smoof = 0.3f;
    public Vector3 offset;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    private Transform target;
    private Vector3 vel = Vector3.zero;
    private Vector3 targetPos;

    void FixedUpdate()
    {
        if (ControlePlayers.paiActive)
        {
            target = pai;
        }
        else if (ControlePlayers.filhoActive)
        {
            target = filho;
        }


        targetPos = target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, Smoof);

         

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), 
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), 
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
