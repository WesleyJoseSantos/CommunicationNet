using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    class CommunicationSerial : Component, ICommunication
    {
        private SerialPort serialPort;

        public SerialPort SerialPort
        {
            get => serialPort;
            set
            {
                serialPort = value;
                serialPort.DataReceived += SerialPort_DataReceived;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceived?.Invoke(sender, e);
        }

        public event EventHandler DataReceived;

        public int DataAvailable()
        {
            return SerialPort.BytesToRead;
        }


        public void GetBytes(out int[] bytes, byte size)
        {
            bytes = new int[size];
            for (int i = 0; i < size; i++)
            {
                bytes[i] = SerialPort.ReadByte();
            }
        }

        public void GetBytes(out byte[] bytes, byte size)
        {
            throw new NotImplementedException();
        }

        public void GetJson(ref IJson json)
        {
            string data = SerialPort.ReadLine();
            json.FromJson(data);
        }

        public string GetString()
        {
            return SerialPort.ReadLine();
        }

        public void SendBytes(byte[] bytes, byte size)
        {
            SerialPort.Write(bytes, 0, size);
        }

        public void SendJson(IJson json)
        {
            SerialPort.WriteLine(json.ToJson());
        }

        public void SendString(string str)
        {
            SerialPort.WriteLine(str);
        }
    }
}
