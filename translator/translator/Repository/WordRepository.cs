using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using translator.Contracts;
using translator.Models;

namespace translator.Repository
{
    public class WordRepository: IWordRepository
    {
        private readonly TranslatorAppDbContext _context;

        public WordRepository(TranslatorAppDbContext context)
        {
            _context = context;
        }

        public async Task<Word> GetByFrom(string from)
        {
            return await _context.Words.Where(w => w.From == from).FirstOrDefaultAsync();
        }

        public async Task<EntityEntry<Word>> Create(Word word)
        {
            return await _context.Words.AddAsync(word);
        }
    }
}
