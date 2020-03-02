using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWord.Models
{
    public class Word
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public string Pronunciation { get; set; }
        public string Definition { get; set; }
        public string Translation { get; set; }

        public int Level { get; set; }
    }
}
