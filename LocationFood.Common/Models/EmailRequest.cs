﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LocationFood.Common.Models
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
