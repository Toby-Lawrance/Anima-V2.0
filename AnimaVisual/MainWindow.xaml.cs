using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;

namespace Anima
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Screen CurrentScreen;
        bool MouseOver;
        AnimaControl AC;
        IntPtr ThisWindowHandle;

        public MainWindow()
        {
            InitializeComponent();
            this.Width = AnimaDisplay.Width;
            this.Height = AnimaDisplay.Height;
            this.Topmost = true;
            AnimaDisplay.IsHitTestVisible = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AC = new AnimaControl();
            AC.PassCode += new EventHandler<AnimaControlEventArgs>(UpdateForm);
            Point Start = AC.DetermineRight(new Anima.Size(this.Width,this.Height));

            SetPosition(Start);

            TraySystem TS = new TraySystem(AC);
            TS.AskToClose += new EventHandler(CloseProgram);


            this.MaxHeight = this.Height;
            this.MaxWidth = this.Width;
            this.MinHeight = this.Height;
            this.MinWidth = this.Width;

        }
        private void SetPosition(Anima.Point Position)
        {
            this.Left = Position.Left;
            this.Top = Position.Top;
            AC.Location = Position;
            Window window = Window.GetWindow(this);
            var wih = new WindowInteropHelper(window);
            ThisWindowHandle = wih.Handle;
            CurrentScreen = Screen.FromHandle(ThisWindowHandle);
        }

        private void CloseProgram(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void UpdateForm(object sender, AnimaControlEventArgs e)
        {
            if (e.Position != new Anima.Point() && e.Position != null && e.Position != AC.Location)
            {
                SetPosition(e.Position);
            }
            while(MouseOver)
            {
               
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Left -= this.Width;
        }

        private void AnimaDisplay_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AnimaDisplay.Opacity = 0.25;
            MouseOver = true;
            //AnimaDisplay.IsHitTestVisible = false;

            UpdateForm(this, new AnimaControlEventArgs(e.ToString()));
        }

        private void AnimaDisplay_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AnimaDisplay.Opacity = 1.0;
            MouseOver = false;
        }
    }
}
