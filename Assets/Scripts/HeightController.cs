using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightController : MonoBehaviour
{
    public float heightChangeRate = .02f;
    public float planePositionChangeRate = 0.2f;
    float hInput;
    float vInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Down"))
        {
            // translate down and localScale up

            transform.position += new Vector3(0, -heightChangeRate, 0);
            transform.localScale += new Vector3(0, heightChangeRate, 0);
        }

        if (Input.GetButton("Up"))
        {
            // translate down and localScale up

            transform.position += new Vector3(0, heightChangeRate, 0);
            transform.localScale += new Vector3(0, -heightChangeRate, 0);
        }

        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hInput, 0, vInput);

        transform.Translate(movement * planePositionChangeRate);
    }
}
