using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public GameObject game;
   
    public void restart()
    {
        if (MarioController.quayphai == false)
        {
            MarioController.quayphai = !MarioController.quayphai;
        }
        MarioController.mang = 3;
        Scoretext.coinamount = 0;
        quathongtrxt.soqua = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void home()
    {
        
        SceneManager.LoadScene(3);
    }
}
