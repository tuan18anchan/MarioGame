using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Livestext : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MarioController.mang < 0)
        {
            MarioController.mang = 0;
        }
        text.text = MarioController.mang.ToString();
    }
}
