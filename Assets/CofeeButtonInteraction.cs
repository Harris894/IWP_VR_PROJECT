using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofeeButtonInteraction : MonoBehaviour
{
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("index"))
        {
            anim.SetTrigger("ButtonPressed");
            //call function to start pouring coffee
        }
    }

}
