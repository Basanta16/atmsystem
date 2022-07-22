
using System.Diagnostics;
using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Linq;



namespace atmsystem
{
	public partial class Withdraw
	{
		public Withdraw()
		{
			InitializeComponent();
			
			
		}
		
#region Default Instance
		
		private static Withdraw defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Withdraw Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Withdraw();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
		System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
		DataSet dset = new DataSet();
		System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
		string balance;
		int num1;
		int num2;
		int total;
		
		
		public void Withdraw_Load(System.Object sender, System.EventArgs e)
		{
			lbldate.Text = DateTime.Now.ToString();
			lblaccno.Text = Mainmenu.Default.lblaccno.Text;
		}
		
		public void btnok_Click(System.Object sender, System.EventArgs e)
		{
			
			string sql = default(string);
			string lastname = default(string);
			DataTable Log_in = new DataTable();
			
			try
			{
				con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ritu raj basanta\\Downloads\\atm system\\obj\\x64\\Debug\\ATMsystem.accdb";
				sql = "SELECT * FROM tblinfo where  account_no = " + lblaccno.Text + "";
				
				cmd.Connection = con;
				cmd.CommandText = sql;
				da.SelectCommand = cmd;
				da.Fill(Log_in);
				if (Log_in.Rows.Count > 0)
				{
					balance = (string) (Log_in.Rows[0]["balance"]);
					lastname = (string)(Log_in.Rows[0]["Lastname"]);
					num1 = int.Parse(balance);
					num2 = int.Parse(txtamount.Text);
					
					if (num2 > 25000)
					{
						MessageBox.Show("You can Only Withdraw NPR 25,000");
					}
					else if (num2 < 200)
					{
						MessageBox.Show(" Minimum withdrawal is 200");
					}
					else if (num1 < num2)
					{
						MessageBox.Show(" Insufficient balance");
						
					}
					else
					{
						total = num1 - num2;
						
						Receipt.Default.Show();
						
						Receipt.Default.lblbal.Text = balance;
						Receipt.Default.lbllname.Text = lastname;
						Receipt.Default.Label4.Hide();
						Receipt.Default.lbldep.Hide();
						Receipt.Default.lblwith.Text = num2.ToString();
						Receipt.Default.lblnewbal.Text = total.ToString();
						
						Receipt.Default.Label5.Show();
						Receipt.Default.Label6.Show();
						
						
						Receipt.Default.lblbal.Show();
						Receipt.Default.lbllname.Show();
						Receipt.Default.Label4.Hide();
						Receipt.Default.lbldep.Hide();
						Receipt.Default.lblnewbal.Show();
						Receipt.Default.lblwith.Show();
						Receipt.Default.lblname.Text = Mainmenu.Default.lblname.Text;
						this.Hide();
						
						
					}
				}
				else
				{
					
					
				}
				
				
				
				
				
				
			}
			catch (Exception)
			{
				MessageBox.Show(" Please Enter Amount!");
			}
			txtamount.Text = "";
			
			
			
		}
		
		public void LinkLabel1_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Mainmenu.Default.Show();
			this.Hide();
		}

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
