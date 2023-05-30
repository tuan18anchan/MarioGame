using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dapda : MonoBehaviour
{
    
    // Start is called before the first frame update

    private int state = 5;
    private Animator hh;
    void Start()
    {
        hh = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hh.SetInteger("state", state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Player" && collision.contacts[0].normal.y > 0)
        {
            state--;
            
            if (state == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
