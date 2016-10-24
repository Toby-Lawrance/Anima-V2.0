using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Anima
{
    public partial class VoiceSelection : Form
    {
        public VoiceSelection()
        {
            InitializeComponent();
        }

        List<System.Speech.Synthesis.InstalledVoice> Voices;

        SpeechSynthesizer Voice = new SpeechSynthesizer();

        private void VoiceSelection_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            Voice.SetOutputToDefaultAudioDevice();

            System.Speech.Synthesis.SpeechSynthesizer VoiceRetrieval = new System.Speech.Synthesis.SpeechSynthesizer();

            Voices = new List<System.Speech.Synthesis.InstalledVoice>();

            Voices.AddRange(VoiceRetrieval.GetInstalledVoices());

            foreach(System.Speech.Synthesis.InstalledVoice Voice in Voices)
            {
                VoicesListBox.Items.Add(Voice.VoiceInfo.Name + " Gender: " + Voice.VoiceInfo.Gender + " Culture: " + Voice.VoiceInfo.Culture.NativeName);
            }
        }

        
        private void VoicesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Voice.SpeakAsyncCancelAll();

            Voice.SelectVoice(Voices[VoicesListBox.SelectedIndex].VoiceInfo.Name);
            TrySpeak();
        }

        private void TrySpeak()
        {
            try
            {
                Voice.Volume = 100;
                Voice.SpeakAsync("Hello. I am Anima, Do you like this voice?");
            }
            catch
            {
                //Add visual view
            }

        }
    }
}
