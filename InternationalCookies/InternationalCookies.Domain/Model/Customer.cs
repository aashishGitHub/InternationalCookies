﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCookies.Domain.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
       
    }
}
