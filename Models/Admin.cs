﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace CandidaturesEnligne.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}