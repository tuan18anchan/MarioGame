using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaonhon : MonoBehaviour
{
    private GameObject mario;
    private void Start()
    {
        mario = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.contacts[0].normal.y < 0 && collision.contacts[0].normal.y < -0.01)
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
