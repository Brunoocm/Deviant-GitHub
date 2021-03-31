using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{

    public bool ZoomActive;
    public bool ZoomActive2;
    public bool ZoomActive3;
    public bool ZoomActive4;

    public Vector3[] Target;

    public Camera Cam;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        ZoomActive = false;
        ZoomActive2 = false;
        ZoomActive3 = false;
        ZoomActive4 = false;

    }

    public void LateUpdate()
    {
        if (ZoomActive == true)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4, speed);
        }

        if (ZoomActive2 == true)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 6, speed);
        }

        if (ZoomActive3 == true)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 7, speed);
        }
        if (ZoomActive4 == true)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 11, speed);
        }




    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Zoom1"))
        {
            ZoomActive = true;
            ZoomActive2 = false;
        }

        if (col.gameObject.CompareTag("Zoom2"))
        {
            ZoomActive2 = true;
            ZoomActive = false;
            ZoomActive3 = false;

        }

        if (col.gameObject.CompareTag("Zoom3"))
        {
            ZoomActive3 = true;
            ZoomActive = false;
            ZoomActive2 = false;
        }
        if (col.gameObject.CompareTag("Zoom4"))
        {
            ZoomActive3 = false;
            ZoomActive = false;
            ZoomActive2 = false;
            ZoomActive4 = true;
        }
    }
}
