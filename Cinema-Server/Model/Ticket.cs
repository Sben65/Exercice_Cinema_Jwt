﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Models
{
    public class Ticket
    {
        public string Id { get; set; }

        public Seance Seance { get; set; }

        public Ticket(string id, Seance seance)
        {
            Id = id;
            Seance = seance;
        }
    }
}