﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerMediaAPI.Models
{
    public partial class Participant
    {
        public Participant()
        {
            TitleParticipants = new HashSet<TitleParticipant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ParticipantType { get; set; }

        internal virtual ICollection<TitleParticipant> TitleParticipants { get; set; }
    }
}