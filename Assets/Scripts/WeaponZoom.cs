using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomIn = 30f;
    [SerializeField] float zoomOut = 60f;
    bool zoomedInToggle = false;

    void Start()
    {
    }
     
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                Camera.main.fieldOfView = zoomIn;
            }
            else
            {
                zoomedInToggle = false;
                Camera.main.fieldOfView = zoomOut;
            }
        }
    }
}
