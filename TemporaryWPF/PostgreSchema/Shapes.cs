﻿using System;
using System.Collections.Generic;

namespace TemporaryWPF.PostgreSchema
{
    public partial class Shapes
    {
        public int Id { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Leftpos { get; set; }
        public int? Toppos { get; set; }
    }
}
