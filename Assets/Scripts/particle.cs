using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour


{
[SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (animator.GetCurrentAnimatorStateInfo(-1).normalizedTime > 1)
            print("full cycle");
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
