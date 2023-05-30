using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mariochet : MonoBehaviour
{
    Vector2 vitrichet;
    public float todonay = 20.5f;
    public float donay = 50f;
    private void Start()
    {
        vitrichet = transform.localPosition;
    }
    private void Update()
    {
        StartCoroutine(Hmariochet());
    }
    IEnumerator Hmariochet()
    {
       
        while (true)
        {
            transform.localPosition=new Vector2(transform.localPosition.x, transform.localPosition.y+todonay*Time.deltaTime );
            if(transform.localPosition.y >= vitrichet.y +donay) 
                break;
            yield return null;
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - todonay * Time.deltaTime);
            if (transform.localPosition.y <= -7f)
            {
                Destroy(gameObject);
                break;
            }
            yield return null;
        }
    }
}
