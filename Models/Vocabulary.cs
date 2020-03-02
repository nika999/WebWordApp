using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWord.Models
{
    public class Vocabulary
    {
        public int Id { get; set; }

        public int WordId { get; set; }
        // дата покупки
        public DateTime Date { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
        public Word Word { get; set; }

    }
}
