﻿using FilmoSearch.DAL.Entities;
using System.Collections.Generic;

namespace FilmoSearch.BLL.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
