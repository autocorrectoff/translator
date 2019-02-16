using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace translator.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        IWordRepository Words { get; }
        ITranslationResultXmlRepository TranslationResults { get; }

        int Complete();
    }
}
