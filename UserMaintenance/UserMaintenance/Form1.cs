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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.FullName; // label1
            btnAdd.Text = Resource1.Add; // button1
            fajl.Text = Resource1.File;
            btnDelete.Text = Resource1.Delete;

            // listbox1
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text,                
            };
            users.Add(u);
        }

        //fájlba írás

        private void fajl_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();  //bin/Debug mappába mentsünk
            if (sfd.ShowDialog()!=DialogResult.OK)
            {
                return;
            }

            using (StreamWriter sw=new StreamWriter(sfd.FileName,true,Encoding.UTF8))
            {
                foreach (var item in users)
                {
                    sw.Write(item.ID);
                    sw.Write(item.FullName);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            users.RemoveAt(listUsers.SelectedIndex); //kitörli amire rákattintok
        }
    }
}
