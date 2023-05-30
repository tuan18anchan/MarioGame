using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossdi : MonoBehaviour
{
    public float speed = 2.5f;
    Transform player;
    Rigidbody2D rd;
    float attackrange = 2f;
    boss boss;
    Animator hh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rd = GetComponent<Rigidbody2D>();
        boss = GetComponent<boss>();
        hh= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        boss.Lookat();
        Vector2 target = new Vector2(player.position.x, rd.position.y);
        Vector2 newPos = Vector2.MoveTowards(rd.position, target, speed * Time.fixedDeltaTime);
        rd.MovePosition(newPos);
        if (Mathf.Abs(player.localPosition.x-transform.localPosition.x) <= attackrange && player.localPosition.y < -2.1)
        {

            hh.SetTrigger("danh");
        }
        
    }
}
