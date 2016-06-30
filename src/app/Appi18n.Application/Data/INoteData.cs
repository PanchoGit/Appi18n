using System.Collections.Generic;
using Appi18n.Application.Model;

namespace Appi18n.Application.Data
{
    public interface INoteData
    {
        IEnumerable<Note> GetAll();

        Note Save(Note item);
    }
}
