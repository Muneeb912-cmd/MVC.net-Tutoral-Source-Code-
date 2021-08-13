
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace FirstWebApp.Models
{
    public class Person
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cnic { get; set; }

        [Required]
        public string BirthDay { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

    }
}