using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp2.Models.Service;
using WpfApp2.Repository;
using Xunit.Sdk;

namespace Tests
{
    [TestClass]
    public class MessageServiceTest
    {
        
        [TestMethod]
        public void AddMessage_StringText_Bool_Test()
        {
            string hello = "Hello,world!!!";
            bool status = true;
            JsonFileSave jsonFile = new JsonFileSave();
            MessageService message =new MessageService(jsonFile);
            bool act = message.AddMessage(hello);
            Assert.AreEqual(status, act);
        }

        [TestMethod]
        public void GetEndText_Message_Test()
        {
         
            JsonFileSave jsonFile = new JsonFileSave();
            MessageService message = new MessageService(jsonFile);
            var act = message.GetEndText();
            Assert.AreEqual("Maxim", act.UserName);
        }
    }
}
