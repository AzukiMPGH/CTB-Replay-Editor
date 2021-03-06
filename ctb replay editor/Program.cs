﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ctb_replay_editor {
    static class Program {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetProcessDPIAware();

        public static int CurrentAudioStream;
        public static MainForm Form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //init form
            Form = new MainForm();
            Form.Show();

            //init playfield
            //this is now the blocking call
            Form.PlayField = new PlayField(Form.playfieldPictureBox.Handle);
            Form.PlayField.Run();
        }
    }
}
