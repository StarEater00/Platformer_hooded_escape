using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour


{
    [SerializeField] private Transform player_pos; 
    [SerializeField] private Transform fire_pos;
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        //var pos = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        print(fire_pos.position.x - player_pos.position.x); 
         if ((fire_pos.position.x - player_pos.position.x) < 2 && (fire_pos.position.x - player_pos.position.x) > -2 )
         {
            
            GetComponent<SpriteRenderer>().enabled = true;
         }
         else{
            GetComponent<SpriteRenderer>().enabled = false;
         }
        
         
    }
}