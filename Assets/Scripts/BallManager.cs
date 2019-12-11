using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ball;
    public int numberOfBalls;
    public float ballHeight;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            float xPosition = Random.Range(-2.2f, 2.2f);
            float zPosition = Random.Range(-2.2f, 2.2f);


            Vector3 position = new Vector3(xPosition, ballHeight, zPosition);
            Instantiate(ball, position, Quaternion.identity, transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
