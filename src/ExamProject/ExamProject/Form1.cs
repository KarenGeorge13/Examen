using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamProject
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.Size = new Size(1326, 629);
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Георгиевский Карен\nВариант 9");
		}

		private void выходToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK) 
			{
				webBrowser1.Navigate(openFileDialog1.FileName);
				this.Size = new Size(1326, 697);
			}
		}

		private void calculateButton_Click(object sender, EventArgs e)
		{
			try 
			{
				string result = ""; 
				double x = Convert.ToDouble(inputXTextBox.Text);
				double y = Convert.ToDouble(inputYTextBox.Text);
				if (openFileDialog1.SafeFileName == "page1.html")
				{
					if ((y <= 1) && (y >= -1) && (x <= 1) && (x >= -1))
					{
						if ((y == x * x || y == -x * x || x == y * y || x == -y * y))
						{
							result = "Точка находится на границе заштрихованной области";
						}
						else 
						{
							if ((y > x*x && (x > y*y || -x > y*y)) || (-y > x*x && (x > y*y || -x > y*y)))
							{
								result = "Точка принадлежит заштрихованной области";
							}
							else 
							{
								result = "Точка лежит вне заштрихованной области";
							}
						}
					}
					else 
					{
						result = "Точка лежит вне заштрихованной области";
					}
				}
				if (openFileDialog1.SafeFileName == "page2.html")
				{
					if (x >= 0 && y >= 0)
					{
						// прямая y = -x + 3
						if ((x == 0) && (y <= 6 && y >= 3) || (y == 0) && (x <= 6 && x >= 3) || (y * y + x * x == 36) || (y == -x + 3))
						{
							result = "Точка находится на границе заштрихованной области";
						}
						else
						{
							if ((y * y + x * x < 36) && (y > -x + 3))
							{
								result = "Точка принадлежит заштрихованной области";
							}
							else
							{
								result = "Точка лежит вне заштрихованной области";
							}
						}
					}
					else
					{
						result = "Точка лежит вне заштрихованной области";
					}
				}
				calculationResult.Text = result;
                MessageBox.Show(result);
            }
            catch (Exception ex)
			{
                MessageBox.Show(ex.Message);
            }
		}
	}
}
