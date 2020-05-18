using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models.Entity;
using WpfApp2.Repository;

namespace WpfApp2.Models.Service
{
    public class MessageService: IMessageService
    {
        private readonly string _userName = "Maxim";
        private readonly IJsonFileSave _jsonFile;
        private  int maxId=0;
        public MessageService(IJsonFileSave jsonFile)
        {
            _jsonFile = jsonFile;

        }

        public bool AddMessage(string text)
        {
            try
            {

            Message message = new Message();
            ++maxId;
            message.Id = maxId;
            message.Text = text;
            message.UserName = _userName;
            message.Date = DateTime.Now;
            _jsonFile.JsonSave(message);
            return true;
            }
            catch 
            {

                return false;
            }

        }
       public Message GetEndText()
        {
            Message message = _jsonFile.JsonReadEndElement();
            if (message!=null)
            {
                maxId = message.Id;
                return message;
            }
            return null;
        }
    }
}
