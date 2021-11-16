using System;
using System.Collections.Generic;

#nullable disable

namespace project5.Models
{
    public partial class Loaitintuc
    {
        public long Maloaitt { get; set; }
        public string Tenloai { get; set; }
        public bool? Isactive { get; set; }
        public string Isdelete { get; set; }
    }
}
