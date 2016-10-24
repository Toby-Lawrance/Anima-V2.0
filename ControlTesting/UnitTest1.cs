using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anima;

namespace ControlTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StripsNames()
        {
            string Phrase = "Open Toaster";
            Command C = new Command(CommandType.Reply,Phrase,true, "C:/OpenToaster.exe",null);
            Assert.AreNotEqual(Phrase, C.Phrase);
            Assert.AreEqual("Anima " + Phrase, C.Phrase);
        }

        [TestMethod]
        public void ChecksPython()
        {
            string Phrase = "Open Toaster";
            Command C = new Command(CommandType.Reply, Phrase, "C:/OpenToaster.py", null);
            Assert.AreEqual(CommandType.Python, C.TypeOfCommand);
        }
    }
}
