using key_managment_system.DBContexts;
using key_managment_system.Dtos;
using key_managment_system.Models;
using key_managment_system.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace key_managment_system.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        public ICommand FilterCommand { get; }

        public ComboBoxItem _columnFilter { get; set; }
        public ComboBoxItem ColumnFilter
        {
            get { return _columnFilter; }
            set
            {
                if (_columnFilter != value)
                {
                    _columnFilter = value;
                    OnPropertyChanged(nameof(ColumnFilter));
                }
            }
        }

        public string _textFilter { get; set; }
        public string TextFilter
        {
            get { return _textFilter; }
            set
            {
                if (_textFilter != value)
                {
                    _textFilter = value;
                    OnPropertyChanged(nameof(TextFilter));
                }
            }
        }

        private ObservableCollection<ReportsDTO> _users;
        public ObservableCollection<ReportsDTO> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }


        public ReportsViewModel()
        {
            _users = new ObservableCollection<ReportsDTO>();
            FilterCommand = new ViewModelCommand(ExecuteFilterCommand, CanExecuteFilterCommand);

            LoadUsers();
        }

        private bool CanExecuteFilterCommand(object obj)
        {
            return true;
        }

        private async void ExecuteFilterCommand(object obj)
        {/*
            if(!string.IsNullOrEmpty(ColumnFilter.Content.ToString()) && string.Equals(ColumnFilter.Content.ToString(), "First Name"))
            {
                MessageBox.Show("DOSAO DO OVDJE");
                var users = await GetRecordsFromDatabaseAsync_FN("Enis");
                foreach (var user in users)
                {
                    _users.Add(user);
                    Trace.WriteLine(user.Username);
                }

                OnPropertyChanged(nameof(Users)); // Notify that the Users property has changed
                Users = _users;
            }*/
        }

        private async void LoadUsers()
        {
            var users = await GetRecordsFromDatabaseAsync();
            foreach (var user in users)
            {
                _users.Add(user);
            }
        }




        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync()
        {
            
                Context context = new Context();
                var query = from r in context.Records
                            join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                            join u in context.Users on k.Id equals u.Keycard.Id
                            join room in context.Rooms on r.Room.Id equals room.Id
                            select new
                            {
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                Username = u.Username,
                                RoomName = room.Name,
                                SerialNumber = k.SerialNumber,
                                AccessLevel = k.AccessLevel,
                                TimeStamp = r.TimeStamp,
                            };

                // Store the result of the query in a list
                var records = await query.ToListAsync();
                var users = records.Select(x => new ReportsDTO { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();
                return users;
        }

        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync_FN(string ime)
        {
            
            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where u.FirstName.Contains(ime)
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            var users = records.Select(x => new ReportsDTO 
            { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();

            return users;
        }

        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync_LN(string ime)
        {

            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where u.LastName.Contains(ime)
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            var users = records.Select(x => new ReportsDTO
            { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();

            return users;
        }

        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync_EMAIL(string ime)
        {

            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where u.Email.Contains(ime)
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            var users = records.Select(x => new ReportsDTO
            { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();

            return users;
        }

        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync_USERNAME(string ime)
        {

            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where u.Username.Contains(ime)
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            var users = records.Select(x => new ReportsDTO
            { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();

            return users;
        }

        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync_RN(string ime)
        {

            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where room.Name.Contains(ime)
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            var users = records.Select(x => new ReportsDTO
            { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();

            return users;
        }


        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync_SN(string ime)
        {

            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where k.SerialNumber.Contains(ime)
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            var users = records.Select(x => new ReportsDTO
            { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();

            return users;
        }

        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync_AL(string ime)
        {
            AccessLevelEnum temp = new AccessLevelEnum();
            if(ime == "Low")
            {
                temp = AccessLevelEnum.Low;
            }
            else if (ime == "Medium")
            {
                temp = AccessLevelEnum.Medium;
            }
            if (ime == "High")
            {
                temp = AccessLevelEnum.High;
            }
            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where k.AccessLevel == temp
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            var users = records.Select(x => new ReportsDTO
            { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();

            return users;
        }


        public async Task<List<ReportsDTO>> GetRecordsFromDatabaseAsync_ALL(string ime)
        {

            Context context = new Context();
            var query = from r in context.Records
                        join k in context.Keycards on r.SerialNumber equals k.SerialNumber
                        join u in context.Users on k.Id equals u.Keycard.Id
                        join room in context.Rooms on r.Room.Id equals room.Id
                        where u.FirstName.Contains(ime) ||
                        u.LastName.Contains(ime) ||
                        u.Email.Contains(ime) ||
                        u.Username.Contains(ime) ||
                        room.Name.Contains(ime) ||
                        k.SerialNumber.Contains(ime) 
                        select new
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            RoomName = room.Name,
                            SerialNumber = k.SerialNumber,
                            AccessLevel = k.AccessLevel,
                            TimeStamp = r.TimeStamp,
                        };

            // Store the result of the query in a list
            var records = await query.ToListAsync();
            var users = records.Select(x => new ReportsDTO
            { FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Username = x.Username, RoomName = x.RoomName, SerialNumber = x.SerialNumber, AccessLevel = x.AccessLevel, Timestamp = x.TimeStamp }).ToList();

            return users;
        }


    }
}
