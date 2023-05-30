using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kethu2 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mario;
    private void Awake()
    {
        
        mario = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            MarioController.mang--;
            mario.GetComponent<MarioController>().mariodau();
            if (MarioController.mang == 0)
            {
                mario.GetComponent<MarioController>().mariochet();
            }
        }
    }
    
}
