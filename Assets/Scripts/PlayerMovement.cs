using UnityEngine;
using System.IO.Ports;

public class PlayerMovement : MonoBehaviour
{
    SerialPort serial = new SerialPort("/dev/cu.usbserial-10", 9600);
    void Start()
    {
        serial.Open();
        serial.ReadTimeout = 100;      
    }

    void Update()
    {
        string data = serial.ReadLine().Trim();
        string[] values = data.Split(',');
        
        int.TryParse(values[0], out int potValue);
        int.TryParse(values[1], out int btnValue);

        transform.rotation = Quaternion.Euler(0, potValue * 360 / 1023, 0);

        if (btnValue == 0) {
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
    }

    void OnApplicationQuit() {
        serial.Close();
    }
}
