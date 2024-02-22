using key_managment_system.DBContexts;
using key_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace key_managment_system.ViewModels
{
    public class AddUserViewModel : ViewModelBase
    {
        public string _errMsg;
        private string _email;
        private string _firstname;
        private bool _isViewVisible = true;
        private string _keycardid;
        private string _lastname;
        private string _role;

        public AddUserViewModel()
        {
            AddUserCommand = new ViewModelCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
        }

        public AddUserViewModel(string role)
        {
            AddUserCommand = new ViewModelCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
            _role = role;
        }

        public ICommand AddUserCommand { get; }

        public string Email
        { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }

        public string ErrorMessage
        { get => _errMsg; set { _errMsg = value; OnPropertyChanged(nameof(ErrorMessage)); } }

        public string FirstName
        { get => _firstname; set { _firstname = value; OnPropertyChanged(nameof(FirstName)); } }

        public bool IsViewVisible
        { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public string KeycardId
        { get => _keycardid; set { _keycardid = value; OnPropertyChanged(nameof(KeycardId)); } }

        public string LastName
        { get => _lastname; set { _lastname = value; OnPropertyChanged(nameof(LastName)); } }

        public string Role
        { get => _role; set { _role = value; OnPropertyChanged(nameof(Role)); } }

        private bool CanExecuteAddUserCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrEmpty(FirstName) ||
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(KeycardId))
            {
                validData = false;
            }
            else validData = true;

            return validData;
        }

        private async void ExecuteAddUserCommand(object obj)
        {
            var context = new Context();
            List<Keycard> keycards = await context.Keycards.ToListAsync();
            bool keycardExists = false;


            foreach (var keycard in keycards)
            {
                if (keycard.SerialNumber.Equals(KeycardId))
                {

                    keycardExists = true;
                    break;
                }
            }

            if (!keycardExists)
            {
                var a = FirstName;
                var b = LastName;
                var c = Email;
                var d = KeycardId;

                AccessLevelEnum accessLevel;
                RoleEnum role;
                

                if (Role.ToString() == RoleEnum.Manager.ToString())
                {
                    accessLevel = AccessLevelEnum.Medium;
                    role = RoleEnum.Manager;
                }
                else if (Role.ToString() == RoleEnum.Employee.ToString())
                {
                    accessLevel = AccessLevelEnum.Low;
                    role = RoleEnum.Employee;
                }
                else
                {
                    ErrorMessage = "Invalid role!";
                    return;
                }

                Keycard keycard = new Keycard();

                keycard.SerialNumber = d;
                keycard.AccessLevel = accessLevel;
                await context.Keycards.AddAsync(keycard);
                await context.SaveChangesAsync();
                SendEmail(Email, "Welcome to Key Management System - Your RFID Information", keycard.SerialNumber);
                User user = new User
                {
                    FirstName = a,
                    LastName = b,
                    Email = c,
                    Keycard = keycard,
                    Role = role,
                };

                ErrorMessage = "";
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                FirstName = "";
                LastName = "";
                Email = "";
                KeycardId = "";
                Role = "";
            }
            else
            {
                ErrorMessage = "Keycard with the same serial number already exists!";
            }
        }
        private void SendEmail(string toEmail, string subject, string keycardSerialNumber)
        {
            try
            {
                // Set your Gmail SMTP server and credentials
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587; // Gmail SMTP port
                smtpClient.Credentials = new NetworkCredential("mujicvedran7@gmail.com", "hjqn ardh rtox baby");
                smtpClient.EnableSsl = true; // Enable SSL for secure connections

                // Create the email message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("mujicvedran7@gmail.com");
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = subject;

                // Construct a more user-friendly and informative email body
                string body = $"Hello {FirstName} {LastName},\n\n";
                body += "Welcome to the Key Management System! Your registration was successful.\n";
                body += $"To log in, please use the following RFID: {keycardSerialNumber}\n\n";
                body += "Thank you for joining us!\n\n";
                body += "Best regards,\nThe Key Management System Team";

                mailMessage.Body = body;

                // Send the email
                smtpClient.Send(mailMessage);

                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }



    }


}