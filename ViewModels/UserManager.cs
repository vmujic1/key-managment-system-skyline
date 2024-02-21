﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.ViewModels
{
    public class UserManager
    {
        private static UserManager _instance;

        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserManager();
                return _instance;
            }
        }

        public int UserId { get; set; }
        public int KeycardId { get; set; }
        public int Role { get; set; }
        
        public int CurrentRoomId { get; set; }

        private UserManager() { }
    }
}