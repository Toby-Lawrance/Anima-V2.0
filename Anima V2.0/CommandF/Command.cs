using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anima
{
    public enum CommandType
    {
        Open,
        Close,
        Python,
        Special,
        Reply
    }

    public partial class Command
    {
        private bool CMDIsByName;
        
        private string CMDPhrase;

        private string CMDReply;

        private CommandType CMDTypeOfCommand;
        
        private string CMDPath;

        private string[] CMDArguments;

        private const string ListCommand = "COMMAND_LIST";
        private const string VoiceCommand = "VOICE_LIST";
        
    }
}
