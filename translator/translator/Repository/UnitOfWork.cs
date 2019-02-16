using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using translator.Contracts;

namespace translator.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly TranslatorAppDbContext _context;

        public IWordRepository Words { get; private set; }
        public ITranslationResultXmlRepository TranslationResults { get; private set; }

        public UnitOfWork(TranslatorAppDbContext context, IWordRepository words, ITranslationResultXmlRepository results)
        {
            _context = context;
            Words = words;
            TranslationResults = results;
        }

        public int Complete()
        {
            return _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
