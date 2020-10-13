using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FormsApp
{
	public partial class Form1 : Form
	{
		TreeView tree;
		Button btn;
		Label lbl;
		CheckBox box_lbl, box_btn;
		RadioButton r1, r2;
		TextBox txt_box;
		PictureBox pic_box;
		TabControl tabControl;
		TabPage page1, page2, page3;
		ListBox l_box;
		public Form1()
		{
			this.Height = 500;
			this.Width = 600;
			this.Text = "Vorm elementitega";
			tree = new TreeView();
			tree.Dock = DockStyle.Left;
			tree.AfterSelect += Tree_AfterSelect;//TAB что бы добавить функцию
			TreeNode tn = new TreeNode("Elimendid");
			tn.Nodes.Add(new TreeNode("Button-Nupp"));
			//button
			btn = new Button();
			btn.Text = "Vajuta siia";
			btn.Location = new Point(200, 100);
			btn.Width = 120;
			btn.Height = 50;
			btn.Click += Btn_Click;//TAB
			//button end
			tn.Nodes.Add(new TreeNode("Label-Silt"));
			//label
			lbl = new Label();
			lbl.Text = "Tarkvaraarendajad";
			lbl.Size = new Size(120, 30);
			lbl.Location = new Point(130, 200);
			//label end
			tn.Nodes.Add(new TreeNode("CheckBox-Märkeruut"));
			tn.Nodes.Add(new TreeNode("RadioButton-Radionupp"));
			tn.Nodes.Add(new TreeNode("TextBox-Tekstkast"));
			tn.Nodes.Add(new TreeNode("PictureBox-Pildikast"));
			tn.Nodes.Add(new TreeNode("TabControl"));
			tn.Nodes.Add(new TreeNode("MessageBox"));
			tn.Nodes.Add(new TreeNode("ListBox"));
			tn.Nodes.Add(new TreeNode("DataGridView"));
			tn.Nodes.Add(new TreeNode("Menu"));
			tree.Nodes.Add(tn);

			this.Controls.Add(tree);
		}

		private void Tree_AfterSelect(object sender, TreeViewEventArgs e)//созданная функция
		{
			if (e.Node.Text == "Button-Nupp")
			{
				
				this.Controls.Add(btn);
			}
			else if (e.Node.Text == "Label-Silt")
			{
				
				this.Controls.Add(lbl);
			}
			else if (e.Node.Text== "CheckBox-Märkeruut")
			{
				box_btn = new CheckBox();
				box_btn.Text = "Näita nupp";
				box_btn.Location = new Point(130,20);
				this.Controls.Add(box_btn);
				box_btn.CheckedChanged += Box_btn_CheckedChanged;

				box_lbl = new CheckBox();
				box_lbl.Text = "Näita silt";
				box_lbl.Location = new Point(130, 50);
				this.Controls.Add(box_lbl);
				box_lbl.CheckedChanged += Box_lbl_CheckedChanged;

			}
			else if (e.Node.Text== "RadioButton-Radionupp")
			{
				r1 = new RadioButton();
				r1.Text = "Nupp vasakule";
				r1.Location = new Point(300, 20);
				r1.CheckedChanged += new EventHandler(RadioButton_Changed);
				r2 = new RadioButton();
				r2.Text = "Nupp paremale";
				r2.Location = new Point(300, 50);
				r2.CheckedChanged += new EventHandler(RadioButton_Changed);


				this.Controls.Add(r1);
				this.Controls.Add(r2);
			}
			else if (e.Node.Text== "TextBox-Tekstkast")
			{
				string text;
				try
				{
					text=File.ReadAllText("text.txt");
				}
				catch (FileNotFoundException)
				{
					text = "Tekst puudub";
				}
				txt_box = new TextBox();
				txt_box.Multiline = true;
				txt_box.Text = text;
				txt_box.Location = new Point(130, 300);
				txt_box.Width = 200;
				txt_box.Height = 200;
				this.Controls.Add(txt_box);
			}
			else if (e.Node.Text== "PictureBox-Pildikast")
			{
				pic_box = new PictureBox();
				pic_box.Image = new Bitmap("picture.jpg");
				pic_box.Location = new Point(340, 300);
				pic_box.Size = new Size(100, 100);
				pic_box.SizeMode = PictureBoxSizeMode.Zoom;
				pic_box.BorderStyle = BorderStyle.FixedSingle;
				this.Controls.Add(pic_box);
			}
			else if (e.Node.Text== "TabControl")
			{
				tabControl = new TabControl();
				tabControl.Location = new Point(340, 200);
				tabControl.Size = new Size(200, 100);
				page1 = new TabPage("Esimene");
				page2 = new TabPage("Teine");
				page3 = new TabPage("Kolmas");
				tabControl.Controls.Add(page1);
				tabControl.Controls.Add(page2);
				tabControl.Controls.Add(page3);
				tabControl.SelectedIndex = 2;
				Label lbl2 = new Label() { Text="see on esimene leht" };
				Label lbl3 = new Label() { Text = "see on teine leht" };
				Label lbl4 = new Label() { Text = "see on kolmas leht" };
				page1.Controls.Add(lbl2);
				page2.Controls.Add(lbl3);
				page3.Controls.Add(lbl4);
				page1.BackColor = Color.Red;
				page2.BackColor = Color.Blue;
				page3.BackColor = Color.Green;
				this.Controls.Add(tabControl);
				
			}
			else if (e.Node.Text== "MessageBox")
			{
				MessageBox.Show("MessageBox", "Kõige lihtsam aken");
				var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
				if (answer==DialogResult.Yes)
				{
					string text = Interaction.InputBox("Siseta siia mingi tekst", "InputBox", "Mingi tekst");//если не работает, то в references найти есть ли visualBasic
					if (MessageBox.Show("kas sa tahad tekst saada Tekskastisse?","teksti salvetamine",MessageBoxButtons.OKCancel)==DialogResult.OK)
					{
						lbl.Text = text;
						Controls.Add(lbl);
					}
				}
			}
			else if (e.Node.Text=="ListBox")
			{
				string[] colors_nim =new string[] {"Kollane","Punane", "Roheline","Sinine"};//массив
				l_box=new ListBox();

				foreach(var item in colors_nim){
					l_box.Items.Add(item);
				}
				l_box.Location=new Point(280,240);
				l_box.Width=colors_nim[2].Length*6;
				l_box.Height=colors_nim.Length*15;
				this.Controls.Add(l_box);
			}
			else if (e.Node.Text=="Menu")
			{
				MainMenu menu=new MainMenu();
				MenuItem menuitem1 = new MenuItem("File");	
				menuitem1.MenuItems.Add("Exit", new EventHandler(menuitem1_Exit));
				menu.MenuItems.Add(menuitem1);
				this.Menu=menu;
			}
			/*
			else if (e.Node.Text=="DataGridView")
			{
				DataSet dataSet=new DataSet("Näide");
				dataSet.ReadXml("../../Files/ex.xml");
				DataGridView dgv = new DataGridView();
				dgv.Location=new Point(300,200);
				dgv.Width=250;
				dgv.Height=250;
				dgv.AutoGenerateColumns=true;
				dgv.DataMember="food";
				dgv.DataSource=dataSet;
				Controls.Add(dgv);

			}*/
			

		}

		private void menuitem1_Exit(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void RadioButton_Changed(object sender, EventArgs e)
		{
			if (r1.Checked)
			{
				btn.Location = new Point(130,100);
			}
			else if (r2.Checked)
			{
				btn.Location=new Point(400,100);
			}
		}

		private void Box_lbl_CheckedChanged(object sender, EventArgs e)
		{
			if (box_lbl.Checked)
			{
				this.Controls.Add(lbl);
			}
			else
			{
				Controls.Remove(lbl);
			}
		}

		private void Box_btn_CheckedChanged(object sender, EventArgs e)
		{
			if (box_btn.Checked)
			{
				this.Controls.Add(btn);
			}
			else
			{
				Controls.Remove(btn);
			}
		}

		private void Btn_Click(object sender, EventArgs e)//function btn clicked
		{
			if (btn.BackColor == Color.Blue)
			{
				btn.BackColor = Color.Red;
				lbl.BackColor = Color.Green;
				lbl.ForeColor = Color.White;
			}
			else
			{
				btn.BackColor = Color.Blue;
				lbl.BackColor = Color.White;
				lbl.ForeColor = Color.Green;
			}
			
		}
	}
}