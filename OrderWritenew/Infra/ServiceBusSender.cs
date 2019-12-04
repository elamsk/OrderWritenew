using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using OrderWritenew.Events;

namespace OrderWritenew.Infra
{
    public interface IServiceBusSender
    {
        void SendMessage(IEvents Evt);

    }
    public class ServiceBusSender : IServiceBusSender
    {
        private string _connectionstring;
        private string _topic;
        private TopicClient client;

        public ServiceBusSender(string connectionstring, string topic)
        {
            _connectionstring = connectionstring;
            _topic = topic;
            client = new TopicClient(_connectionstring, _topic);
        }
        public void SendMessage(IEvents Evt)
        {
            string mymsg = JsonConvert.SerializeObject(Evt);
            Message m = new Message();
            m.Body = System.Text.Encoding.ASCII.GetBytes(mymsg);
            client.SendAsync(m).GetAwaiter().GetResult();
        }
    }
}
