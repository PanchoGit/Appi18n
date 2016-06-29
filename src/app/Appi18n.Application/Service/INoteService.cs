using System.Collections.Generic;
using Appi18n.Application.Model;

namespace Appi18n.Application.Service
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
    }
}
