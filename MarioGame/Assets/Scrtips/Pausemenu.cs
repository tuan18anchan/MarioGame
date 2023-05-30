using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public GameObject Pausedmenu;
    public void Pause()
    {
        
        Pausedmenu.SetActive(true);
        Time.timeScale= 0f;
        
    }
    public void Resume()
    {
        
        Pausedmenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(int id)
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(id);
    }
}
