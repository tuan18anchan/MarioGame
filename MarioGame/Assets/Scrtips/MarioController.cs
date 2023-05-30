using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioController : MonoBehaviour
{
    private float nhaycao = 150;
    public static bool quayphai=true;
    private float vantoc=5f;
    private float Tocdo=0f;
    private bool Duoidat;
    private Rigidbody2D r2d;
    private Animator hoathoa;
    private Vector2 vitrichet;
    private Renderer rend;
    private Color c;
    public GameObject gameover;
    public projectbehivior Projectbehivior;
    public static int mang = 3;
    public Transform lauchoff;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Duoidat = true;
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        r2d= GetComponent<Rigidbody2D>();
        hoathoa= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nhaylen();
        hoathoa.SetFloat("Tocdo", Tocdo);
        hoathoa.SetBool("Duoidat", Duoidat);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (quathongtrxt.soqua > 0)
            {
                Instantiate(Projectbehivior, lauchoff.position, transform.rotation);
                quathongtrxt.soqua--;
            }
        }
    }
    private void FixedUpdate()
    {
        Dichuyen();
       
    }
    private void Dichuyen()
    {
        float phimtraiphai = Input.GetAxis("Horizontal");
        r2d.velocity = new Vector2(vantoc * phimtraiphai, r2d.velocity.y);
        Tocdo = Mathf.Abs(vantoc * phimtraiphai);
        if (phimtraiphai > 0 && !quayphai) huongmat();
        if (phimtraiphai < 0 && quayphai) huongmat();
    }
    private void huongmat()
    {
        quayphai=! quayphai;
        Vector2 huongquay = transform.localScale;
        huongquay.x *= -1;
        transform.localScale = huongquay;
    }
    private void nhaylen()
    {
        
        if(Input.GetKey(KeyCode.UpArrow) && Duoidat == true)
        {    
            r2d.AddForce((Vector2.up) * nhaycao);
            Duoidat = false;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "nendat")
        {
            Duoidat = true;
            
        }
        if (collision.tag == "boss" && boss.attack)
        {
            print("cham");
            mang--;
            mariodau();
            if (mang == 0)
            {
                mariochet();
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "nendat")
        {
            Duoidat = true;
            
        }
        if (collision.tag == "boss" && boss.attack)
        {
            print("cham");
            mang--;
            mariodau();
            if (mang == 0)
            {
                mariochet();
            }
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "duongdoc")
        {
            Duoidat = true; 
        }
        if (collision.collider.tag == "boss" && collision.contacts[0].normal.y > 0 && collision.contacts[0].normal.x==0)
        {
           
            Duoidat = true;
           collision.gameObject.GetComponent<boss>().bossdau();
            collision.gameObject.GetComponent<boss>().takedamage(10f);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "duongdoc")
        {
            Duoidat = true;
            
        }
        
    }
    public void mariochet()
    {
        
        gameObject.SetActive(false);
        vitrichet = transform.localPosition;
        GameObject mariochet =(GameObject) Instantiate(Resources.Load("Prefab/Lepchet"));
        mariochet.transform.localPosition=vitrichet;
       gameover.SetActive(true);
       Destroy(mariochet,1);
    }
    public void mariodau()
    {
        hoathoa.SetTrigger("dau");
        StartCoroutine(gethurt());
    }
    IEnumerator gethurt()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        c.a = 0.5f;
        rend.material.color = c;
        
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        c.a = 1f;
        rend.material.color = c;
    }
}
