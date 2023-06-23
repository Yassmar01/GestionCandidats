using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace CandidaturesEnligne.Models
{
    public partial class Candidat
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string NiveauDetude { get; set; }
        [Required]
        public int Experiance { get; set; }
        [Required]
        public string DernierEmployeur { get; set; }
        [Required]
        public string CvPath { get; set; }
    }
}
