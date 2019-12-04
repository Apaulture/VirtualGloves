using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

// This script is attached to each of the five fingers (top and bottom portions)

public class FingerController : MonoBehaviour
{
    string portName;
    int baudRate;
    string arduinoMessage;
    string[] splitMessage;
    float[] bendAngle;

    SerialPort serial;
    Thread thread;
    Queue outputQueue;
    Queue inputQueue;

    void Start()
    {
        portName = "/dev/cu.usbmodem146101"; // Enter the port name here from Tools > Port
        baudRate = 9600;

        serial = new SerialPort(portName, baudRate);
        serial.ReadTimeout = 50;
        serial.Open(); // Open port for serial communication

        // StartThread();
    }

    void Update()
    {
        arduinoMessage = serial.ReadLine();
        splitMessage = arduinoMessage.Split(','); // split message into multiple bend angles

        for (int i = 1; i <= 5; i++)
        {
            bendAngle[i] = float.Parse(splitMessage[i]);

            // Distal phalanx (top joint) bends 2x as much as middle joint
            if (gameObject.CompareTag("top") && transform.name == "finger" + i)
            {
                transform.eulerAngles = new Vector3(-bendAngle[i], 0, 0);
            }

            // Middle phalanx (middle joint) bends 1/2 the angle of top joint
            if (gameObject.CompareTag("mid") && transform.name == "finger" + i)
            {
                bendAngle[i] *= 0.5f; // reduce bend angle by a half since the mid portion bends twice less than top
                transform.eulerAngles = new Vector3(-bendAngle[i], 0, 0);
            }
        }
    }

    /*
     * All code below is for multithreading but isn't currently working
     */

    void StartThread()
    {
        // Synchronized queues allow messages to be sent and received across threads
        // When this script wants to talk to Arduino, it places the message in an input queue
        outputQueue = Queue.Synchronized(new Queue());
        inputQueue = Queue.Synchronized(new Queue());

        thread = new Thread(ThreadLoop);
        thread.Start();
    }

    void ThreadLoop()
    {
        

        while (true)
        {
            if (outputQueue.Count != 0)
            {
                string command = (string)outputQueue.Dequeue();
                WriteToArduino(command);
            }
        }
    }

    public void SendToArduino(string command)
    {
        outputQueue.Enqueue(command); // adds "command" to end of queue to be sent out to Arduino
    }

    public string ReadFromArduino()
    {
        if (inputQueue.Count == 0) // if no input, don't do anything
            return null;

        return (string) inputQueue.Dequeue(); // removes and returns object at beginning of queue
    }

    public void WriteToArduino(string message)
    {
        serial.WriteLine(message);
        serial.BaseStream.Flush();
    }
}
