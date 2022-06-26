﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerBee.Models
{
    public class Book
    {

        #region Properties

        public string Description { get; set; }


        public DateTime EndDate { get; set; }


        public string Name { get; set; }


        public string SaveLocation { get; set; }


        public DateTime StartDate { get; set; }
        #endregion
    }
}
