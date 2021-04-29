using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    interface IJsonMsg : IJson
    {
        int MsgId { get; set; }
    }
}
