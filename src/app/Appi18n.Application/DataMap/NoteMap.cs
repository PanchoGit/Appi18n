using Appi18n.Application.Model;
using FluentNHibernate.Mapping;

namespace Appi18n.Application.DataMap
{
    public class NoteMap : ClassMap<Note>
    {
        public NoteMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Text);
            Map(x => x.Date);
        }
    }
}
