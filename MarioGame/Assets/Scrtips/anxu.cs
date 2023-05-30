using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anxu : MonoBehaviour
{
    
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.tag == "xu")
        {
            Scoretext.coinamount += 1;
            Destroy(gameObject);
        }
        else if (collision.tag == "Player" && this.tag == "quathong")
        {
            quathongtrxt.soqua += 1;
            Destroy(gameObject);
        }
        else if (collision.tag == "Player" && this.tag == "co3la")
        {
            MarioController.mang++;
            Destroy(gameObject);
        }
    }
}
