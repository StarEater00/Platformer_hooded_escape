using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class change_color : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        //  GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Enemy.GetComponent<SpriteRenderer>().enabled == true) 
        //     {
        //        GetComponent<SpriteRenderer>().enabled = true;
        //        GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 110f);
        //     }
        // if(Enemy.GetComponent<SpriteRenderer>().enabled == false)
        //     {
        //         GetComponent<SpriteRenderer>().enabled = true;
        //         GetComponent<SpriteRenderer>().color = new Color(200f, 200f, 200f, 16f);
        //     }

        
    }
}
