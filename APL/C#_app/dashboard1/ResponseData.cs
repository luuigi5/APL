﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashboard1
{
    public class ResponseData
    {
        public string token { get; set; }
        public User user { get; set; }
        public Structure structure { get; set; }
        public List<Structure> structures { get; set; }

        public int status { get; set; }

        public string error { get; set; }
    }
}
