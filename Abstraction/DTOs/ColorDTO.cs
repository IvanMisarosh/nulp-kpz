using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Abstraction.DTOs
{
    public class ColorDTO : IColor
    {
        public int ColorID { get; set; }

        public string ColorName { get; set; }
    }
}
