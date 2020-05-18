using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models.Entity;

namespace WpfApp2.Repository
{
    public class JsonFileSave : IJsonFileSave
    {
        public Message JsonReadEndElement()
        {
            List<Message> messages = new List<Message>();
            messages = GetAllMessages();
            if (messages!=null)
            {
                return messages.OrderByDescending(i => i.Id).FirstOrDefault();
            }
            return null;
        }
        private List<Message> GetAllMessages()
        {
            List<Message> messages = new List<Message>();
            using (StreamReader r = new StreamReader("file.json"))
            {
                string jsonr = r.ReadToEnd();
                messages = JsonConvert.DeserializeObject<List<Message>>(jsonr);
            }
            return messages;
        }
        public bool JsonSave(Message message)
        {
            try
            {
                List<Message> messages = new List<Message>();
                if (message.Id>1)
                {

                messages = GetAllMessages();
                }

                messages.Add(message);
                var json = JsonConvert.SerializeObject(messages, Formatting.Indented);
                // serialize JSON to a string and then write string to a file
                //File.WriteAllText(@"file.json", JsonConvert.SerializeObject(movie));

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(@"file.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, messages);
                }



                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
