﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerMediaAPI.Models
{
    public partial class TitleGenre
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        internal virtual Title Title { get; set; }
    }
}