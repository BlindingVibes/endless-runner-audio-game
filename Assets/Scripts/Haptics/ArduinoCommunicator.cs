using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoCommunicator : MonoBehaviour
{
    SerialPort sp;
    bool cArduino, errSend;

    // Use this for initialization
    void Start()
    {
        string the_com = "";

        foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps != "COM1") { the_com = mysps; cArduino = true; break; }
        }

        if (cArduino)
        {
            sp = new SerialPort("\\\\.\\" + the_com, 115200);
            if (!sp.IsOpen)
            {
                print("Opening " + the_com + ", baud 115200");
                sp.Open();
                sp.ReadTimeout = 100;
                sp.WriteTimeout = 100;
                sp.Handshake = Handshake.None;
                if (sp.IsOpen) { print("Open"); /* Readies the arduino for com.*/  sp.WriteLine("M0,0,70,0,0;"); }
            }
        }
    }

    // Update is called once per frame
    public new void SendMessage(string message)
    {
        if (cArduino)
        {
            
                if (!sp.IsOpen)
                {
                    sp.Open();
                    print("opened sp");
                }
                if (sp.IsOpen)
                {
                    print("Writing " + message);
                    sp.WriteLine(message);
                }
        } else
        {
            if (!errSend)
            {
                print("Arduino is not connected!");
                errSend = true;
            }
        }
        
    }
}
