using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Lab2.Composite;
using Newtonsoft.Json;
namespace Lab2
{
    public class CustomGroupBox : GroupBox
    {
        public TaskComponent Component { get; set; }

    }
}
