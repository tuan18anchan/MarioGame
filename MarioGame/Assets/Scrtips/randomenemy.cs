using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomenemy : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector2 valuesvtr1;
    public Vector2 valuesvtr2;
    public float spawnwait;
    public int startwait;
    public bool stop;
    float time = 15;
    int randenemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
       
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0  && spawnwait>2f)
        {
            spawnwait -= 0.5f;
            time= 15;
        }
        else if(spawnwait == 2f)
        {
            time = 0;
        }
        print(time);
    }
    private void FixedUpdate()
    {
         
    }
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startwait);
        while (!stop)
        {
            randenemy = Random.Range(0,enemies.Length);
            Vector2 position = new Vector2(Random.Range(valuesvtr1.x, valuesvtr2.x), Random.Range(valuesvtr1.y, valuesvtr2.y));
            Instantiate(enemies[randenemy], position, Quaternion.identity);
            yield return new WaitForSeconds(spawnwait);
        }
    }

}
