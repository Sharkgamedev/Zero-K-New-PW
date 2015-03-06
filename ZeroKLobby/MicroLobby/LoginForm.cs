﻿using System;
using System.Windows.Forms;

namespace ZeroKLobby.MicroLobby
{
	public partial class LoginForm: Form
	{
		public string InfoText { set { lbInfo.Text = value; } }

		public string LoginValue {
            get
            {
                return tbLogin.Text;
            } 
        }

		public string PasswordValue { 
            get {
                return tbPassword.Text;
            }
        }

	    protected override void OnPaintBackground(PaintEventArgs e)
	    {
            //base.OnPaintBackground(e);
            FrameBorderRenderer.Instance.RenderToGraphics(e.Graphics, DisplayRectangle, FrameBorderRenderer.StyleType.Shraka);
	    }


		public LoginForm()
		{
            InitializeComponent();

            tbLogin.Text = Program.Conf.LobbyPlayerName;
		    if (string.IsNullOrEmpty(tbLogin.Text)) {
		        tbLogin.Text = Program.SteamHandler.SteamName;
                Program.SteamHandler.SteamHelper.SteamOnline += SteamApiOnSteamOnline;
		    }
		    tbPassword.Text = Program.Conf.LobbyPlayerPassword;
        }

	    void SteamApiOnSteamOnline()
	    {
	        Program.MainWindow.InvokeFunc(() =>
	        {
	            if (string.IsNullOrEmpty(tbLogin.Text)) {
	                tbLogin.Text = Program.SteamHandler.SteamName;
	            }
	            Program.SteamHandler.SteamHelper.SteamOnline -= SteamApiOnSteamOnline;
	        });
	    }

	    void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}


		void btnSubmit_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
            Icon = ZklResources.ZkIcon;
        }
	}
}