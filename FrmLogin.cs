using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;

namespace Evaluation_Manager
{
    public partial class FrmLogin : Form
    {
        public static Teacher LoggedTeacher { get; set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        public static Teacher LockTeacher { get; set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (LockTeacher != null)

                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Korisničko ime nije uneseno!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Lozinka nije unesena!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LoggedTeacher = TeacherRepository.GetTeacher(txtUsername.Text);
                    if (LoggedTeacher != null && LoggedTeacher.CheckPassword(txtPassword.Text))
                    {
                        FrmStudents frmStudents = new FrmStudents();
                        Hide();
                        frmStudents.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Krivi podaci!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
    }
}
