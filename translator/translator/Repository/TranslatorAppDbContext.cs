using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using translator.Models;

namespace translator.Repository
{
    public class TranslatorAppDbContext: DbContext {

        public DbSet<Word> Words { get; set; }
        public DbSet<TranslationResultXml> TranslationResults { get; set; }

        public TranslatorAppDbContext(DbContextOptions<TranslatorAppDbContext> options): base(options)
        {
                
        }
    }
}
