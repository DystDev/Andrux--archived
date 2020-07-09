using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    Text myText;
    
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float fps = (1.0f / Time.smoothDeltaTime);
        float roundFPS = Mathf.Round(fps);
        myText.text = roundFPS.ToString();
    }
}
