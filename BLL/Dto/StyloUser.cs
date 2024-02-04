using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class StyloUser
    {
        public List<Stylo> stylos {  get; set; }
        public User user { get; set; }

    }
}
