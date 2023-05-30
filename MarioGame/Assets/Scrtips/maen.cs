using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class maen : MonoBehaviour
{
    public GameObject Object;
    // Start is called before the first frame updat
    // e
    public void Play()
    {
        if (MarioController.quayphai == false)
        {
            MarioController.quayphai = !MarioController.quayphai;
        }
        MarioController.mang = 3;
        Scoretext.coinamount = 0;
        quathongtrxt.soqua = 0;
        SceneManager.LoadScene(0);
    }
    public void Quitgame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void tutoron()
    {
        Object.SetActive(true);
    }
    public void tutoroff()
    {
        Object.SetActive(false);
    }
}
