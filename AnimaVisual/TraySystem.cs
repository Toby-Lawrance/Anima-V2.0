using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Anima
{
    public class TraySystem
    {
        private NotifyIcon m_notifyIcon;
        private ContextMenu TrayMenu;
        private AnimaControl AC;

        public event EventHandler AskToClose;

        public TraySystem(AnimaControl _AC)
        {
            AC = _AC;

            TrayMenu = new ContextMenu();
            TrayMenu.Name = "Anima V2.0";
            TrayMenu.MenuItems.Add("Settings",OpenSettings); //Set to the settings form, for now just the voice one.
            TrayMenu.MenuItems.Add("Exit",CloseProgram);

            m_notifyIcon = new NotifyIcon();
            m_notifyIcon.Text = "Anima V2.0";
            m_notifyIcon.Visible = true;
            m_notifyIcon.Icon = new System.Drawing.Icon(SystemIcons.Information, 40, 40);
            m_notifyIcon.ContextMenu = TrayMenu;

            //m_notifyIcon.DoubleClick += new System.EventHandler(TrayClick);
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            Form Settings = new Anima.VoiceSelection();
            Settings.Show();
        }

        private async void CloseProgram(object sender, EventArgs e)
        {
            AC.AnimaSpeak("Goodbye!");
            await Task.Delay(1000);
            Application.Exit();

            EventHandler handler = AskToClose;
            if (handler != null)
            {
               System.ComponentModel.ISynchronizeInvoke target = handler.Target as System.ComponentModel.ISynchronizeInvoke;

                if (target != null && target.InvokeRequired)
                {
                    target.Invoke(handler, new object[] { this, e });
                }
                else
                {
                    handler(this, e);
                }
            }
        }


        //bool shown = false;
        //private void TrayClick(object sender, EventArgs e)
        //{
        //    if (shown == true)
        //    {
                
        //        shown = false;
        //    }
        //    else
        //    {
                
        //        shown = true;
        //    }
        //}
    }
}
