using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Models
{
    using System;
    public class OutputFileNameAttribute : Attribute
    {
        public OutputFileNameAttribute(String fileName)
        {
            this._fileName = fileName;
        }
        private readonly String _fileName;
        public String FileName
        {
            get
            {
                return this._fileName;

            }
        }
    }
}
