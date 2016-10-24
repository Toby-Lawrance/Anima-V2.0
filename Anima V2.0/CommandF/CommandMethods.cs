using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IronPython.Hosting;


namespace Anima
{
    public partial class Command
    {
        public bool IsByName
        {
            get { return CMDIsByName; }
            set { CMDIsByName = value; UpdatePhrase(); }
        }

        public string Phrase
        {
            get { return CMDPhrase; }
            set { CMDPhrase = value; UpdatePhrase(); UpdateTypeOfCommand(); }
        }

        public string Reply
        {
            get { return CMDReply; }
            set { CMDReply = value; }
        }

        public Anima.CommandType TypeOfCommand
        {
            get { return CMDTypeOfCommand; }
            set { CMDTypeOfCommand = value; }
        }

        public string Path
        {
            get { return CMDPath; }
            set { CMDPath = value; }
        }

        public string[] Arguments
        {
            get { return CMDArguments; }
            set { CMDArguments = value; }
        }
   
        public Command()
        {
            CMDIsByName = false;
            CMDPhrase = string.Empty;
            CMDPath = string.Empty;
            CMDArguments = null;
            CMDTypeOfCommand = CommandType.Reply;
        }

        public Command(CommandType TypeOfCommand, string Phrase, bool IsByName, string Path, params string[] Arguments)
        {
            this.CMDIsByName = IsByName;
            this.CMDPhrase = Phrase;
            this.CMDPath = Path;
            this.CMDTypeOfCommand = TypeOfCommand;
            this.Arguments = Arguments;

            UpdatePhrase();
            UpdateTypeOfCommand();
        }

        public Command(CommandType TypeOfCommand,string Phrase, string Path, params string[] Arguments)
        {
            this.CMDIsByName = false;
            this.CMDPhrase = Phrase;
            this.CMDPath = Path;
            this.CMDTypeOfCommand = TypeOfCommand;
            this.Arguments = Arguments;

            UpdatePhrase();
            UpdateTypeOfCommand();
        }

        private void UpdatePhrase()
        {
            string Named = Properties.Persistent.Default.AnimaName + " ";
            bool StartsWithName = Phrase.StartsWith(Named);
            if (IsByName)
            {
                if (!StartsWithName)
                {
                    CMDPhrase = Named + Phrase;
                }
            }
            else
            {
                if (StartsWithName)
                {
                    CMDPhrase = Phrase.Substring(Named.Length);
                }
            }
        }

        private void UpdateTypeOfCommand()
        {
            if(System.IO.Path.GetExtension(Path) == ".py")
            {
                TypeOfCommand = CommandType.Python;
            }
        }


        public bool ExecuteCommand()
        {
            bool Succeeded = true;




            return Succeeded;
        }
    }

}