using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
			btn.Location = new Point(200, 200);
			btn.Width = 120;
			btn.Height = 50;
			btn.Click += Btn_Click;//TAB
			//button end
			tn.Nodes.Add(new TreeNode("Label-Silt"));
			//label
			lbl = new Label();
			lbl.Text = "Tarkvaraarendajad";
			lbl.Size = new Size(120, 30);
			lbl.Location = new Point(200, 300);
			//label end
			tn.Nodes.Add(new TreeNode("CheckBox-Märkeruut"));
			tn.Nodes.Add(new TreeNode("RadioButton-Radionupp"));
			tn.Nodes.Add(new TreeNode("TextBox-Tekstkast"));
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
				box_btn.Location = new Point(200,50);
				this.Controls.Add(box_btn);
				box_btn.CheckedChanged += Box_btn_CheckedChanged;

				box_lbl = new CheckBox();
				box_lbl.Text = "Näita silt";
				box_lbl.Location = new Point(200, 70);
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
					File.ReadAllText("text.txt");
				}
				catch (FileNotFoundException exception)
				{
					text = "Tekst puudub";
				}
				txt_box = new TextBox();
				txt_box.Multiline = true;
				txt_box.Text = "Fail";
				txt_box.Location = new Point(300, 300);
				txt_box.Width = 200;
				txt_box.Height = 200;
			}
		}

		private void RadioButton_Changed(object sender, EventArgs e)
		{
			if (r1.Checked)
			{
				btn.Location = new Point(150,200);
			}
			else if (r2.Checked)
			{
				btn.Location=new Point(400,200);
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
