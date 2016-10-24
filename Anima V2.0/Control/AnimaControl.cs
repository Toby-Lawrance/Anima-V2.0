using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Anima
{
    public class Size
    {
        public double Width
        { get; set; }

        public double Height
        { get; set; }

       public Size(double _Width, double _Height) { Width = Math.Abs(_Width); Height = Math.Abs(_Height); }
        public Size() { Width = -1; Height = -1; }
    }

    public class Point
    {
        public double Top
        { get; set; }

        public double Left
        { get; set; }

        public Point(double _Left, double _Top) { Left = _Left;  Top = _Top; }
        public Point() { Left = -1; Top = -1; }
    }

    public class ScreenBounds
    {
        public Point TopLeft
        { get; set; }

        public Point BottomRight
        { get; set; }

        public ScreenBounds(System.Windows.Forms.Screen S)
        {
            TopLeft = new Point(S.WorkingArea.Left, S.WorkingArea.Top);

            BottomRight = new Point(S.WorkingArea.Left + S.WorkingArea.Width, S.WorkingArea.Top + S.WorkingArea.Height);
        }
        public ScreenBounds(Point _TopLeft, Point _BottomRight) { TopLeft = _TopLeft; BottomRight = _BottomRight; }
        public ScreenBounds() { TopLeft = new Point(); BottomRight = new Point(); }
    }



    public partial class AnimaControl
    {

        public event EventHandler<AnimaControlEventArgs> PassCode;

        SpeechRecognitionEngine Engine = new SpeechRecognitionEngine();

        public Size WindowSize;
        public SpeechSynthesizer Voice;

        public List<Screen> Screens = new List<Screen>();

        public List<ScreenBounds> Screenbounds = new List<ScreenBounds>();

        public ScreenArray SA = new ScreenArray();

        public Point Location = new Point();

        public Screen CurrentScreen;

        public AnimaControl()
        {

                Engine.LoadGrammar(new DictationGrammar());

                Engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognised);

                Engine.SetInputToDefaultAudioDevice();

                Engine.RecognizeAsync(RecognizeMode.Multiple);


            Voice = new SpeechSynthesizer();

            Voice.SetOutputToDefaultAudioDevice();


            Voice.SelectVoice(Properties.Persistent.Default.VoiceName);



            //foreach (Screen screen in Screen.AllScreens)
            //{
            //    Screens.Add(screen);
            //    Screenbounds.Add(new ScreenBounds(screen));
            //}

            //CurrentScreen = Screen.FromPoint(new DetermineRight(WindowSize));
        }



        public Point DetermineRight(Size WindowSize)
        {
            Screen RightScreen = SA.Arr[SA.Arr.Length-1];
            this.WindowSize = WindowSize;
           
                        
            return new Point(RightScreen.WorkingArea.Width - WindowSize.Width, RightScreen.WorkingArea.Height - WindowSize.Height);
            
        }

        public void DetermineMouseOverMovement()
        {
            var ACE = new AnimaControlEventArgs("Move");
            ACE.Position = this.Location;
            if (Location.Left < Screen.GetWorkingArea(new System.Drawing.Point((int)Location.Left, (int)Location.Top)).Width / 2 + WindowSize.Width)
            {
                ACE.Position.Left += 1;
            }
            else
            {
                ACE.Position.Left -= 1;
            }
            FireEvent(ACE, PassCode);
        }


        protected void SpeechRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            AnimaControlEventArgs ACE = new AnimaControlEventArgs(e.Result.Text);



            FireEvent(ACE, PassCode);
        }

        public void AnimaSpeak(string Message)
        {
            try
            {
                Voice.Volume = 100;
                Voice.SpeakAsync(Message);
            } catch
            {
                //Add visual view
            }

        } 

        public void FireEvent(AnimaControlEventArgs ACE, EventHandler<AnimaControlEventArgs> _Handler)
        {
            EventHandler<AnimaControlEventArgs> handler = _Handler;
            if (handler != null)
            {
                ISynchronizeInvoke target = handler.Target as ISynchronizeInvoke;

                if (target != null && target.InvokeRequired)
                {
                    target.Invoke(handler, new object[] { this, ACE });
                }
                else
                {
                    handler(this, ACE);
                }
            }
        }
    }
}
