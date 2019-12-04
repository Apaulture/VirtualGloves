using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string someText = "Hey there dude";
        string[] splitText = someText.Split(' ');
        print(splitText[0]);
        print(splitText[1]);
        print(splitText[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
