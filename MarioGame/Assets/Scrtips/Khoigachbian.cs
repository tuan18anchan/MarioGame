using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Khoigachbian : MonoBehaviour
{
    private Vector2 vitrian;
    public bool co3la;
    public bool xu;
    public bool thong;
    private Vector2 vitrilucdau;
    // Start is called before the first frame update
    void Start()
    {
        vitrilucdau = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.contacts[0].normal.y > 0)
        {
            vitrian = transform.localPosition;
            GameObject khoibian = (GameObject)Instantiate(Resources.Load("Prefab/Khoibian"));
            khoibian.transform.localPosition = vitrian;
            Destroy(gameObject);
            phanthuong();
        }
    }
    private void phanthuong()
    {
        GameObject phanthuong = null;
        if (co3la)
        {
            phanthuong = (GameObject)Instantiate(Resources.Load("Prefab/co3la"));
            phanthuong.transform.SetParent(this.transform.parent);
            phanthuong.transform.localPosition = new Vector2(vitrilucdau.x, vitrilucdau.y + 1f);
        }
        if (thong)
        {
            phanthuong = (GameObject)Instantiate(Resources.Load("Prefab/quathong"));
            phanthuong.transform.SetParent(this.transform.parent);
            phanthuong.transform.localPosition = new Vector2(vitrilucdau.x, vitrilucdau.y + 1f);
        }
        if (xu)
        {
            phanthuong = (GameObject)Instantiate(Resources.Load("Prefab/xu"));
            phanthuong.transform.SetParent(this.transform.parent);
            phanthuong.transform.localPosition = new Vector2(vitrilucdau.x, vitrilucdau.y + 1f);
            Scoretext.coinamount++;
            Destroy(phanthuong,0.1f);
        }
    }
}
