using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pointtext : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int pointamount = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        text.text = pointamount.ToString();
    }
}
