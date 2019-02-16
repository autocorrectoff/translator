using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using translator.Models;

namespace translator.Contracts
{
    public interface IWordRepository
    {
        Task<Word> GetByFrom(string from);
        Task<EntityEntry<Word>> Create(Word word);
    }
}
