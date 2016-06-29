using System.Collections.Generic;
using Appi18n.Application.Data;
using Appi18n.Application.Model;

namespace Appi18n.Application.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteData data;

        public NoteService(INoteData data)
        {
            this.data = data;
        }

        public IEnumerable<Note> GetAll()
        {
            return data.GetAll();
        }
    }
}
