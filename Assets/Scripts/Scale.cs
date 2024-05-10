using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Scale : MonoBehaviour
{
    public float SizeChange;
    [SerializeField] private GameObject player;
    
    //private Background background;
    // Start is called before the first frame update
    void Start()
    {
       transform.localScale = transform.localScale + new Vector3(SizeChange,SizeChange);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(player.transform.position.x ,0,-.5f);  
    }
}
