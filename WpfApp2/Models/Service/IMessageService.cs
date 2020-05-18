using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models.Entity;

namespace WpfApp2.Models.Service
{
   public interface IMessageService
    {
        bool AddMessage(string text);
        Message GetEndText();
    }
}
