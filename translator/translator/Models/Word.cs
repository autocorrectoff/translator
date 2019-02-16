using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace translator.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
