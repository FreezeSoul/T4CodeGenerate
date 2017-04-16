using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGen.Models;

namespace CodeGen.Models
{
    public interface ITemplate
    {
        bool IncludeRelationships { get; set; }
        Table Table { get; set; }
        Tables Tables { get; set; }
        string TransformText();
    }
}
