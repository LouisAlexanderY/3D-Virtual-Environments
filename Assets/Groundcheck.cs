using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{

    //references
    private KaineController placeholder;

   void Start()
    {
        placeholder = gameObject.GetComponentInParent<KaineController>();   
    }

   void OnTriggerEnter2D(Collider2D col)
    {
        placeholder.grounded = true;
    }

   void OnTriggerStay2D(Collider2D col)
    {
        placeholder.grounded = true;
    }

   void OnTriggerExit2D(Collider2D col)
    {
        placeholder.grounded = false;
    }
}
