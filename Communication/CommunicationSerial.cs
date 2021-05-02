using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public partial class CommunicationSerial : Component, ICommunication
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

        public CommunicationSerial()
        {
            InitializeComponent();
        }

        public CommunicationSerial(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
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

        public string GetString()
        {
            var data = SerialPort.ReadLine();
            Console.WriteLine("RX:" + data);
            return data;
        }

        public void SendBytes(byte[] bytes, byte size)
        {
            SerialPort.Write(bytes, 0, size);
        }

        public void SendString(string str)
        {
            SerialPort.Write(str + '\n');
            Console.WriteLine("TX:" + str);
        }

        public void SendJson(object obj)
        {
            var data = JsonConvert.SerializeObject(obj);
            SerialPort.Write(data + '\n');
            Console.WriteLine("TX:" + data);
        }

        public Type GetJson<Type>()
        {
            var data = SerialPort.ReadLine();
            Console.WriteLine("RX:" + data);
            return JsonConvert.DeserializeObject<Type>(data);
        }
    }
}
