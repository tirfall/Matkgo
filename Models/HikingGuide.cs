﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matkgo.Models
{
    public class HikingGuide
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Equipment { get; set; }
        public string SafetyTips { get; set; }
        public byte[] Img { get; set; }
    }
}
