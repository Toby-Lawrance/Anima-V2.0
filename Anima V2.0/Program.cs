using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Anima
{
    static class Program
    {

       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AnimaControl AC;
            AC = new AnimaControl();


            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                Console.WriteLine("Installed voices -");
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;
                    Console.WriteLine(" Voice Name: " + info.Name);
                }
            }

            //AC.AnimaSpeak("Irashai-masen Goshujin-sama");

            

            Console.WriteLine();
            Console.WriteLine("Name: " + AC.Voice.Voice.Name);
            Console.WriteLine("Gender: " + AC.Voice.Voice.Gender);
            Console.WriteLine("Age: " + AC.Voice.Voice.Age);
            Console.WriteLine("Culture: " + AC.Voice.Voice.Culture);
            Console.WriteLine("Description: " + AC.Voice.Voice.Description);
            Console.WriteLine();
            //Poem(ref AC);
            ScreenArray SA = new ScreenArray();
            Console.WriteLine("Screen Array: ");

            PrintScreenArray(ref AC);

            Console.ReadKey();
        }

        private static void PrintScreenArray(ref AnimaControl AC)
        {
                Console.Write("[");
                for (int Column = 0; Column < Screen.AllScreens.Length /* -1 */; Column++)
                {
                    if (AC.SA.Arr[Column] == null)
                    {
                        Console.Write("No Screen");
                    } 
                    else
                    {
                    var IsPrimary = AC.SA.Arr[Column].Primary ? " Primary" : " Secondary";
                        Console.Write("Screen:" + AC.SA.Arr[Column].DeviceName + IsPrimary);
                    }
                }
                Console.WriteLine("]");
        }

        private static void Poem(ref AnimaControl AC)
        {
            List<string> Poem = new List<string>();
            while (true)
            {
                Console.Write("Say: ");
                string Message = Console.ReadLine();
                if (Message == "")
                {
                    break;
                }
                Poem.Add(Message);
                AC.AnimaSpeak(Message);
            }


            foreach (string line in Poem)
            {
                AC.AnimaSpeak(line);
            }
        }
    }

    
}
