﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerMediaAPI.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Titles = new HashSet<Title>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        internal virtual ICollection<Title> Titles { get; set; }
        internal virtual ICollection<TitleGenre> TitleGenres { get; set; }
    }
}