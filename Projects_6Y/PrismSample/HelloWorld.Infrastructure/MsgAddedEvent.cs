using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace HelloWorld.Infrastructure
{
    public class MsgAddedEvent : PubSubEvent<MessageStructure>
    {
    }
}
