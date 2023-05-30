using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gate : MonoBehaviour
{
    public float delaysecond = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(MarioController.quayphai==false)
            {
                MarioController.quayphai = !MarioController.quayphai;
            }
                collision.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
    private void modeselect()
    {
        StartCoroutine("Loadafterdelay()");
    }
    IEnumerator Loadafterdelay()
    {
        yield return new WaitForSeconds(delaysecond);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
