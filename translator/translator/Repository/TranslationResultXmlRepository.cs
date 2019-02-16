using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using translator.Contracts;
using translator.Models;

namespace translator.Repository
{
    [Serializable]
    public class WordXml
    {
        [XmlAttribute]
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        [XmlAttribute]
        public DateTime TimeStamp { get; set; }

        public WordXml()
        {
        }
    }

    public class TranslationResultXmlRepository: ITranslationResultXmlRepository
    {
        private readonly TranslatorAppDbContext _context;

        public TranslationResultXmlRepository(TranslatorAppDbContext context)
        {
            _context = context;
        }

        public async Task<EntityEntry<TranslationResultXml>> Create(Word word)
        {
            var xml = GetXmlFromObject(word);
            var trRes = new TranslationResultXml
            {
                Result = xml
            };
            return await _context.TranslationResults.AddAsync(trRes);
        }

        private WordXml WordToWordXml(Word word)
        {
            var wordxml = new WordXml();
            wordxml.Id = word.Id;
            wordxml.From = word.From;
            wordxml.To = word.To;
            wordxml.TimeStamp = word.TimeStamp;
            return wordxml;
        }

        private string GetXmlFromObject(object o)
        {
            if (o is Word)
            {
                o = WordToWordXml(o as Word);
            }
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
    }
}
