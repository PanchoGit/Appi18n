using Appi18n.Application.Model;
using Common;

namespace Appi18n.Application.Service
{
    public interface INoteService
    {
        Result GetAll();

        Result Save(Note item);
    }
}
