﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    public TextMesh text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            text.text = score.ToString();
            score++;
            
            
        }
    }
}
