using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CreateDB
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.VScrollBar vScrollBar2;
		private System.Windows.Forms.VScrollBar vScrollBar1;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.VScrollBar vScrollBar3;
		private System.Windows.Forms.VScrollBar vScrollBar4;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Button button4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		struct DatabaseParam 
		{
			public string	ServerName;
			public string	DatabaseName;
			//Data file parameters
			public string	DataFileName;
			public string	DataPathName;
			public string	DataFileSize;	
			public string	DataFileGrowth;	
			//Log file parameters
			public string	LogFileName;
			public string	LogPathName;
			public string	LogFileSize;
			public string	LogFileGrowth;					
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.vScrollBar3 = new System.Windows.Forms.VScrollBar();
			this.vScrollBar4 = new System.Windows.Forms.VScrollBar();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(464, 245);
			this.button3.Name = "button3";
			this.button3.TabIndex = 6;
			this.button3.Text = "&Cancel";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(368, 245);
			this.button2.Name = "button2";
			this.button2.TabIndex = 5;
			this.button2.Text = "&OK";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(530, 224);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(522, 198);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(128, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "DatabaseName";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(248, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(168, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "TestDB";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.textBox3);
			this.tabPage2.Controls.Add(this.textBox2);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(522, 198);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Data file";
			this.tabPage2.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(8, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(504, 120);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "File properties";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox6);
			this.groupBox3.Controls.Add(this.radioButton4);
			this.groupBox3.Controls.Add(this.radioButton3);
			this.groupBox3.Location = new System.Drawing.Point(240, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(256, 88);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Maximum file size";
			// 
			// textBox6
			// 
			this.textBox6.Enabled = false;
			this.textBox6.Location = new System.Drawing.Point(184, 48);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(48, 20);
			this.textBox6.TabIndex = 2;
			this.textBox6.Text = "5000";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(24, 48);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(160, 24);
			this.radioButton4.TabIndex = 1;
			this.radioButton4.Text = "Restricted file growth (MB)";
			this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(24, 24);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(144, 16);
			this.radioButton3.TabIndex = 0;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Unrestricted file growth";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.vScrollBar2);
			this.groupBox2.Controls.Add(this.vScrollBar1);
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(this.textBox4);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Location = new System.Drawing.Point(8, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(216, 88);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "File growth";
			// 
			// vScrollBar2
			// 
			this.vScrollBar2.Location = new System.Drawing.Point(184, 48);
			this.vScrollBar2.Name = "vScrollBar2";
			this.vScrollBar2.Size = new System.Drawing.Size(16, 16);
			this.vScrollBar2.TabIndex = 5;
			this.vScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar2_Scroll);
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Enabled = false;
			this.vScrollBar1.Location = new System.Drawing.Point(184, 16);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(16, 16);
			this.vScrollBar1.TabIndex = 4;
			this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(128, 48);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(56, 20);
			this.textBox5.TabIndex = 3;
			this.textBox5.Text = "10";
			// 
			// textBox4
			// 
			this.textBox4.Enabled = false;
			this.textBox4.Location = new System.Drawing.Point(128, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(56, 20);
			this.textBox4.TabIndex = 2;
			this.textBox4.Text = "1";
			// 
			// radioButton2
			// 
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(16, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "By percent";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "in megabytes";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(24, 24);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(112, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Text = "TestDB_Data";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(160, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(176, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "C:\\TestDB_Data.mdf";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(360, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Browse...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Controls.Add(this.textBox10);
			this.tabPage3.Controls.Add(this.textBox11);
			this.tabPage3.Controls.Add(this.button4);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(522, 198);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Log file";
			this.tabPage3.Visible = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.groupBox5);
			this.groupBox4.Controls.Add(this.groupBox6);
			this.groupBox4.Location = new System.Drawing.Point(8, 63);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(504, 120);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "File properties";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.textBox7);
			this.groupBox5.Controls.Add(this.radioButton5);
			this.groupBox5.Controls.Add(this.radioButton6);
			this.groupBox5.Location = new System.Drawing.Point(240, 16);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(256, 88);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Maximum file size";
			// 
			// textBox7
			// 
			this.textBox7.Enabled = false;
			this.textBox7.Location = new System.Drawing.Point(184, 48);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(48, 20);
			this.textBox7.TabIndex = 2;
			this.textBox7.Text = "5000";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(24, 48);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(160, 24);
			this.radioButton5.TabIndex = 1;
			this.radioButton5.Text = "Restricted file growth (MB)";
			this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
			// 
			// radioButton6
			// 
			this.radioButton6.Checked = true;
			this.radioButton6.Location = new System.Drawing.Point(24, 24);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(144, 16);
			this.radioButton6.TabIndex = 0;
			this.radioButton6.TabStop = true;
			this.radioButton6.Text = "Unrestricted file growth";
			this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.vScrollBar3);
			this.groupBox6.Controls.Add(this.vScrollBar4);
			this.groupBox6.Controls.Add(this.textBox8);
			this.groupBox6.Controls.Add(this.textBox9);
			this.groupBox6.Controls.Add(this.radioButton7);
			this.groupBox6.Controls.Add(this.radioButton8);
			this.groupBox6.Location = new System.Drawing.Point(8, 16);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(216, 88);
			this.groupBox6.TabIndex = 0;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "File growth";
			// 
			// vScrollBar3
			// 
			this.vScrollBar3.Location = new System.Drawing.Point(184, 48);
			this.vScrollBar3.Name = "vScrollBar3";
			this.vScrollBar3.Size = new System.Drawing.Size(16, 16);
			this.vScrollBar3.TabIndex = 5;
			this.vScrollBar3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar3_Scroll);
			// 
			// vScrollBar4
			// 
			this.vScrollBar4.Enabled = false;
			this.vScrollBar4.Location = new System.Drawing.Point(184, 16);
			this.vScrollBar4.Name = "vScrollBar4";
			this.vScrollBar4.Size = new System.Drawing.Size(16, 16);
			this.vScrollBar4.TabIndex = 4;
			this.vScrollBar4.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar4_Scroll);
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(128, 48);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(56, 20);
			this.textBox8.TabIndex = 3;
			this.textBox8.Text = "10";
			// 
			// textBox9
			// 
			this.textBox9.Enabled = false;
			this.textBox9.Location = new System.Drawing.Point(128, 16);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(56, 20);
			this.textBox9.TabIndex = 2;
			this.textBox9.Text = "1";
			// 
			// radioButton7
			// 
			this.radioButton7.Checked = true;
			this.radioButton7.Location = new System.Drawing.Point(16, 48);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.TabIndex = 1;
			this.radioButton7.TabStop = true;
			this.radioButton7.Text = "By percent";
			this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
			// 
			// radioButton8
			// 
			this.radioButton8.Location = new System.Drawing.Point(16, 16);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.TabIndex = 0;
			this.radioButton8.Text = "in megabytes";
			this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(24, 24);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(112, 20);
			this.textBox10.TabIndex = 6;
			this.textBox10.Text = "TestDB_Log";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(160, 24);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(176, 20);
			this.textBox11.TabIndex = 5;
			this.textBox11.Text = "C:\\TestDB_Log.ldf";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(360, 24);
			this.button4.Name = "button4";
			this.button4.TabIndex = 4;
			this.button4.Text = "Browse...";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 277);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create SQL Server Database using C# - PhuongNT";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			
			DatabaseParam DBParam = new DatabaseParam();
			DBParam.DatabaseName = textBox1.Text;
			//Assign Data file parameters
			if(radioButton1.Checked == true)
			{
				DBParam.DataFileGrowth = textBox4.Text;
			}
			else DBParam.DataFileGrowth = textBox5.Text + "%";
			DBParam.DataFileName = textBox3.Text;
			DBParam.DataFileSize = "2";//2MB at the init state
			DBParam.DataPathName = textBox2.Text;
			//Assign Log file parameters
			if(radioButton8.Checked == true)
			{
				DBParam.LogFileGrowth = textBox9.Text;
			}
			else DBParam.LogFileGrowth = textBox8.Text+ "%";
			DBParam.LogFileName = textBox10.Text;
			DBParam.LogFileSize = "1";//1MB at the init state
			DBParam.LogPathName = textBox11.Text;

			
			CreateDatabase(DBParam);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			
			this.Close();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = "c:\\" ;
			saveFileDialog.Filter = "Data files (*.ldf)|*.ldf" ;
			saveFileDialog.FilterIndex = 2 ;		
			saveFileDialog.RestoreDirectory = true ;			
			saveFileDialog.FileName += textBox10.Text;
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				textBox11.Text = saveFileDialog.FileName;						
			}				
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();// new OpenFileDialog();

			saveFileDialog.InitialDirectory = "c:\\" ;
			saveFileDialog.Filter = "Data files (*.mdf)|*.mdf" ;
			saveFileDialog.FilterIndex = 2 ;		
			saveFileDialog.RestoreDirectory = true ;			
			saveFileDialog.FileName += textBox3.Text;
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				textBox2.Text = saveFileDialog.FileName;				
			}		
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			textBox3.Text = textBox1.Text + "_Data";
			textBox10.Text = textBox1.Text + "_Log";			
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox4.Enabled = true;
			textBox5.Enabled = false;
			vScrollBar1.Enabled = true;
			vScrollBar2.Enabled = false;
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox4.Enabled = false;
			textBox5.Enabled = true;
			vScrollBar1.Enabled = false;
			vScrollBar2.Enabled = true;
		}

		private void vScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			textBox4.Text = vScrollBar1.Value.ToString();
		}

	
		
		#region Handle radio buttons and ScrollBars events
		private void vScrollBar3_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			textBox8.Text = vScrollBar3.Value.ToString();
		}

		private void radioButton8_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox9.Enabled = true;
			vScrollBar4.Enabled = true;
			textBox8.Enabled = false;
			vScrollBar3.Enabled = false;
		}

		private void radioButton7_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox9.Enabled = false;
			vScrollBar4.Enabled = false;
			textBox8.Enabled = true;
			vScrollBar3.Enabled = true;
		
		}

		private void radioButton4_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox6.Enabled = true;
		}

		private void radioButton6_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox7.Enabled = false;		
		}

		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox6.Enabled = false;
		}

		private void radioButton5_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox7.Enabled = true;
		}
		private void vScrollBar2_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			textBox5.Text = vScrollBar2.Value.ToString();		
		}

		private void vScrollBar4_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			textBox9.Text = vScrollBar4.Value.ToString();
		}

		#endregion Handle radio buttons and ScrollBars events

		private void CreateDatabase(DatabaseParam DBParam)
		{
			System.Data.SqlClient.SqlConnection tmpConn;			
			string sqlCreateDBQuery;
			tmpConn = new SqlConnection();
			tmpConn.ConnectionString = "SERVER = " + DBParam.ServerName + "; DATABASE = master; User ID = sa; Pwd = sa";												
			
			sqlCreateDBQuery =	  " CREATE DATABASE " + DBParam.DatabaseName + " ON PRIMARY "
								+ " (NAME = " + DBParam.DataFileName +", " 
								+ " FILENAME = '" + DBParam.DataPathName +"', "
								+ " SIZE = 2MB,"
								+ "	FILEGROWTH =" + DBParam.DataFileGrowth  +") "
								+ " LOG ON (NAME =" + DBParam.LogFileName +", "
								+ " FILENAME = '" + DBParam.LogPathName + "', "
								+ " SIZE = 1MB, "								
								+ "	FILEGROWTH =" + DBParam.LogFileGrowth  +") ";	
	
			SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, tmpConn);			
			try
			{
				tmpConn.Open();
				MessageBox.Show(sqlCreateDBQuery);
				myCommand.ExecuteNonQuery();				
				
				MessageBox.Show("Database has been created successfully!", "Create Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Create Database", MessageBoxButtons.OK, MessageBoxIcon.Information);				
			}
			finally
			{	
				tmpConn.Close();				
			}			
			return;		
		}
	}
}
