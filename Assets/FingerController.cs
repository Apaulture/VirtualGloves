using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class FingerController : MonoBehaviour
{
    SerialPort serial;
    string portName;

    // Start is called before the first frame update
    void Start()
    {
        portName = "COM6"; // Enter the port name here from Tools > Port
        serial = new SerialPort(portName, 9600);
        serial.Open();
    }

    // Update is called once per frame
    void Update()
    {
        print(serial.ReadLine());
        float bendAngle = float.Parse(serial.ReadLine());
        print(bendAngle);
        transform.eulerAngles = new Vector3(-90f, -bendAngle, 0);
    }
}
