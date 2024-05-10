using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Zoom : MonoBehaviour
{
    public float ZoomChange;
    private Camera cam;
    private Background background;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
       //background = GetComponent<Background>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.orthographicSize = ZoomChange;
        transform.position = cam.transform.position; //new Vector3(cam.transform.position.x,0,-.5f);
    }
}
