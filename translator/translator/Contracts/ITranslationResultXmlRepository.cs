using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using translator.Models;

namespace translator.Contracts
{
    public interface ITranslationResultXmlRepository
    {
        Task<EntityEntry<TranslationResultXml>> Create(Word word);
    }
}
