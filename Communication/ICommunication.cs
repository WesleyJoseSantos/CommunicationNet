using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    interface ICommunication
    {
        event EventHandler DataReceived;
        void SendString(string str);
        void SendBytes(byte[] bytes, byte size);
        void SendJson(IJson json);
        int DataAvailable();
        string GetString();
        void GetBytes(out byte[] bytes, byte size);
        void GetJson(ref IJson json);
    }
}
