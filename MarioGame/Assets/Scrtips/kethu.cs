using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class kethu : MonoBehaviour
{
    
   
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Player" && (collision.contacts[0].normal.x > 0 || collision.contacts[0].normal.x < 0) && collision.contacts[0].normal.y>-0.01)
        {
            MarioController.mang--;
            collision.gameObject.GetComponent<MarioController>().mariodau();
            if(MarioController.mang==0)
            {
                collision.gameObject.GetComponent<MarioController>().mariochet();
                
            }   
        }
        if(collision.collider.tag == "Player" && collision.contacts[0].normal.y < 0 && collision.contacts[0].normal.y < -0.01)
        {
            kethuchet();
        }
        
    }

    public void kethuchet()
    {
            Vector2 huongmat = transform.localScale;
            huongmat.y *= -1;
            transform.localScale = huongmat;
           GetComponent<kethudichuyen>().settocdo(0);
           GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(gameObject,2);
    }
}
