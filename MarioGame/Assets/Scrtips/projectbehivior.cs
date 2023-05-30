using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectbehivior : MonoBehaviour
{
    public float speed = 5;
    public Vector3 lauchoff;
    public bool Throw;
   
    // Start is called before the first frame update

    void Start()
    {
        
        if (Throw)
        {
     
            if (MarioController.quayphai)
            {
                var direction = transform.right + Vector3.up;
                GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
            }
            else
            {
                var direction = -transform.right + Vector3.up;
                GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
            }
            }
        transform.Translate(lauchoff);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Throw)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag =="kethu" && collision.contacts[0].normal.y > 0 && collision.contacts[0].normal.y > -0.01)
        {
            Destroy(collision.gameObject);   
            Destroy(gameObject); 
        }
        if (collision.collider.tag == "nendat")
        {

            Destroy(gameObject);
        }
        if (collision.collider.tag == "boss" )
        {
            collision.gameObject.GetComponent<boss>().takedamage(20f);
            Destroy(gameObject);
        }
    }
}
