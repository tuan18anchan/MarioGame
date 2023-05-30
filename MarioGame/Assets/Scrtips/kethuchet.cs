using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kethuchet : MonoBehaviour
{
    GameObject kethu;
    Vector2 vitrichet;
    // Start is called before the first frame update
    private void Awake()
    {
        kethu = GameObject.FindGameObjectWithTag("kethu");
    }

    // Update is called once per frame
    void Update()
    {
        vitrichet= transform.localPosition;
        if (vitrichet.y < -7f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Player" && collision.contacts[0].normal.y < 0)
        {
            Vector2 huongmat = transform.localScale;
            huongmat.y *= -1;
            transform.localScale = huongmat;
            kethu.GetComponent<kethudichuyen>().settocdo(0);
            kethu.GetComponent<BoxCollider2D>().isTrigger= true;
        }
    }
}
