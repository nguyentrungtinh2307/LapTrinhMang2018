using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace BT1Tuan8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                    smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(txtSender.Text.Trim(), txtPass.Text.Trim());
                    //smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    
                using (MailMessage mm = new MailMessage(txtSender.Text.Trim(), txtSendto.Text.Trim()))
                {
                    mm.Subject = txtSubject.Text;
                    mm.Body = txtBody.Text;
                 
                    mm.IsBodyHtml = false;
                    
                    
                   
                    smtp.Send(mm);
                    MessageBox.Show("Email sent.", "Message");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
