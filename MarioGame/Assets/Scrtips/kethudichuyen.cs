using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class kethudichuyen : MonoBehaviour
{
    private float tocdo ;
    public bool dichuyentrai = true;
    private Vector2 vitrichet;
    // Start is called before the first frame update
    public void settocdo(float x) 
    { 
        tocdo = x;
    }
    private void Awake()
    {
        tocdo = Random.Range(1, 3);
    }
    private void FixedUpdate()
    {
        Vector2 dichuyen = transform.localPosition;
        if (dichuyentrai)
        {
            dichuyen.x -= tocdo * Time.deltaTime;
        }
        else
        {
            dichuyen.x += tocdo * Time.deltaTime;
        }
        transform.localPosition = dichuyen;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.collider.tag != "nendat" && collision.collider.tag != "Player" && collision.contacts[0].normal.x > 0)
            {
                quaymat();
                dichuyentrai = false;

            }
            if (collision.collider.tag != "nendat" && collision.collider.tag != "Player" && collision.contacts[0].normal.x < 0)
            {
                quaymat();
                dichuyentrai = true;
            }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gioihanene" )
        {
            quaymat();
            dichuyentrai = !dichuyentrai;

        }
        
    }
    public GameObject emy;
    private void OnMouseDown()
    {
        if(biengioi.ktrxn)
        {
        Destroy(gameObject);
        pointtext.pointamount++;
        vitrichet = transform.localPosition;
            print("vitri:"+vitrichet);
        Instantiate(emy,vitrichet, Quaternion.identity);
            print("emy:"+emy.transform.localPosition);
        }
        
    }
    private void quaymat()
    {
        Vector2 huongmat = transform.localScale;
        huongmat.x *= -1;
        transform.localScale= huongmat;
    }
}
