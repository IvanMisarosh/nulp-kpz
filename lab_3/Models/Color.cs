using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.ModelInterfaces;

namespace Wpf.Models
{
    public class Color : IColor
    {
        public int ColorID { get; set; }

        public string ColorName { get; set; }
    }
}
