using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models.Entity
{
     public class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime Date{ get; set; }

    }
}
