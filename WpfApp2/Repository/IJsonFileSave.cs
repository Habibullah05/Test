using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models.Entity;

namespace WpfApp2.Repository
{
    public interface IJsonFileSave
    {
        Message JsonReadEndElement();
        bool JsonSave(Message message);

    }
}

