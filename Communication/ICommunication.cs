using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public interface ICommunication
    {
        event EventHandler DataReceived;
        void SendString(string str);
        void SendBytes(byte[] bytes, byte size);
        int DataAvailable();
        string GetString();
        void GetBytes(out byte[] bytes, byte size);
        Type GetJson<Type>();
        void SendJson(object obj);
    }
}
