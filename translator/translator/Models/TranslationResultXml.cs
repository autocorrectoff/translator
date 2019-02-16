using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace translator.Models
{
    public class TranslationResultXml
    {
        [Key]
        public int Id { get; set; }

        [MaxLength]
        public string Result { get; set; }
    }
}
