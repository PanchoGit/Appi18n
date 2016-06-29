using System;

namespace Appi18n.Application.Model
{
    public class Note
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Text { get; set; }

        public virtual DateTime Date { get; set; }
    }
}
