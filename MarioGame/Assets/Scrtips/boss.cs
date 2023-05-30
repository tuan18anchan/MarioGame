using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public Image healthbar;
    public float healthamount = 100f;
    public Transform player;
    public bool isfillip = false;
    public static bool attack;
    private Renderer rend;
    private Color c;
    private Vector2 vitrichet;
    public GameObject gamewon;
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }
    public void Update()
    {
        if (healthamount <= 0)
        {
            bosschet();
        }
    }
    public void Lookat()
    {
        Vector3 fillip = transform.localScale;
        fillip.z *= -1;
        if (transform.position.x > player.position.x && isfillip)
        {
            transform.localScale = fillip;
            transform.Rotate(0f, 180f, 0f);
            isfillip = false;
        }
        else if (transform.position.x < player.position.x && !isfillip)
        {
            transform.localScale = fillip;
            transform.Rotate(0f, 180f, 0f);
            isfillip = true;
        }
    }
    public void takedamage(float dam)
    {
        healthamount -= dam;
        healthbar.fillAmount = healthamount / 100f;
    }
    public void bossdau()
    {
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
    public void bosschet()
    {
        vitrichet = transform.localPosition;
        GameObject bosschet = (GameObject)Instantiate(Resources.Load("Prefab/bosschet"));
        bosschet.transform.localPosition = vitrichet;
        Destroy(gameObject);
        Destroy(bosschet, 5);
       
        gamewon.SetActive(true);
    }
}
