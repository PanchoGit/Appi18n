using System.Collections.Generic;
using Appi18n.Application.Model;

namespace Appi18n.Application.Data
{
    public class NoteData : INoteData
    {
        private readonly IRepositoryBase<Note> repositaryBase;

        public NoteData(IRepositoryBase<Note> repositaryBase)
        {
            this.repositaryBase = repositaryBase;
        }

        public IEnumerable<Note> GetAll()
        {
            return repositaryBase.GetAll();
        }

        public Note Save(Note item)
        {
            return repositaryBase.Save(item);
        }
    }
}
