﻿using PassApp.Data.Models.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Data.Models
{
    public class Record : Keyable
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string? Link { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
    }
}