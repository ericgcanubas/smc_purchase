using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSS
{
    class EmailHelper
    {

        private static string iniFilePath = "config.ini";

        // Read Emails from INI
        public static List<string> ReadEmails()
        {
            List<string> emails = new List<string>();

            if (File.Exists(iniFilePath))
            {
                var lines = File.ReadAllLines(iniFilePath);
                foreach (var line in lines)
                {
                    if (line.Contains("=")) // Check for key-value pair
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            emails.Add(parts[1]); // Store email values
                        }
                    }
                }
            }
            return emails;
        }

        // Add Email to INI
        public static void AddEmail(string email)
        {
            var emails = ReadEmails();
            string newLine = $"email{emails.Count + 1}={email}";

            File.AppendAllText(iniFilePath, newLine + Environment.NewLine);
            Console.WriteLine("Email added successfully!");
        }

        // Update Email in INI
        public static void UpdateEmail(string oldEmail, string newEmail)
        {
            var lines = File.ReadAllLines(iniFilePath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(oldEmail))
                {
                    lines[i] = lines[i].Replace(oldEmail, newEmail);
                    File.WriteAllLines(iniFilePath, lines);
                    Console.WriteLine("Email updated successfully!");
                    return;
                }
            }
            Console.WriteLine("Email not found!");
        }

        // Delete Email from INI
        public static void DeleteEmail(string email)
        {
            var lines = File.ReadAllLines(iniFilePath).ToList();
            var newLines = lines.Where(line => !line.Contains(email)).ToList();

            if (newLines.Count < lines.Count) // If any change occurred
            {
                File.WriteAllLines(iniFilePath, newLines);
                Console.WriteLine("Email deleted successfully!");
            }
            else
            {
                Console.WriteLine("Email not found!");
            }
        }

        public static MailMessage mailMsg(string senderEmail, string Subject, string Body, string SendToEmail, string[] attachment)
        {


            // Sender email credentials
            //   string senderEmail = "ericgcanubas@gmail.com";
            //   string senderPassword = "wlwa idgi ifou bslr"; // Use App Password

            // Email configuration
            MailMessage mail = new MailMessage();




            foreach (string file in attachment)
            {
                if (System.IO.File.Exists(file)) // Check if file exists before adding
                {
                    mail.Attachments.Add(new Attachment(file));
                }
                else
                {
                    MessageBox.Show($"File not found: {file}");
                    mail = null;
                    return mail;
                }
            }

            mail.From = new MailAddress(senderEmail);
            mail.To.Add(SendToEmail);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;



            return mail;

        }
        public static void Smtp(MailMessage mail, string senderEmail, string senderPassword)
        {                       

                
            // SMTP Configuration
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(mail);
        }
    }
}
