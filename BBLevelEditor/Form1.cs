using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BBLevelEditor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void buildButton_Click(object sender, EventArgs e)
        {

            XmlWriter writer = XmlWriter.Create("Resources/brick.xml", null);

            writer.WriteStartElement("level");

            foreach (Control c in panel1.Controls)
            {
                if (c is Button)
                {
                    writer.WriteStartElement("brick");

                    writer.WriteElementString("x", Convert.ToString(c.Location.X));
                    writer.WriteElementString("y", Convert.ToString(c.Location.Y));
                    writer.WriteElementString("hp", c.Text);
                    writer.WriteElementString("colour", Convert.ToString(c.BackColor));

                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();

            writer.Close();
        }
    }
}
