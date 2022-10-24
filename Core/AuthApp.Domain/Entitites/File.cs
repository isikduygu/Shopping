using AuthApp.Domain.Entitites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Entitites
{
    public class File : BaseEntities
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
    }
}
