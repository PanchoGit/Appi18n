using System;
using System.Collections.Generic;
using Appi18n.Application.Data;
using Appi18n.Application.Model;
using Common;

namespace Appi18n.Application.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteData data;

        public NoteService(INoteData data)
        {
            this.data = data;
        }

        public Result GetAll()
        {
            return new Result<IEnumerable<Note>>(data.GetAll());
        }

        public Result Save(Note item)
        {
            return new Result<Note>(data.Save(item));
        }
    }
}
