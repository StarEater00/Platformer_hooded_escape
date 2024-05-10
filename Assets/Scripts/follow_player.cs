using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Collections;
using UnityEngine;




public class follow_player : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var cam = GetComponent<Camera>();
    
         
        Vector3 cam_pos = transform.position;
        cam_pos.x = player.position.x;
        cam_pos.y = player.position.y;
        
        
        transform.position = new Vector3(cam_pos.x,0,cam_pos.z);
        
        //pos.x = player.position.x + offset.x;
    }
}
