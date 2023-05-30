using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biengioi : MonoBehaviour
{
    public bool ktr = true;
    public static bool ktrxn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag=="Player" && ktr)
        {
            
            ktrxn = true;
            
        }
        if (collision.tag == "Player" && !ktr)
        {
           
            ktrxn = false;
            
        }
    }
}
