using ProjectBOT.Arena.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectBOT.Arena.Base
{
    public class ProjectBotList<T> : List<T> where T : IEntry
    {
        public virtual string ToDisplayList()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
                sb.AppendLine($"{i + 1}  {this[i].Name}");

            return sb.ToString();
        }

        public virtual string ToDisplayList(int page = 1)
        {
            StringBuilder sb = new StringBuilder();
            int index = page == 1 ? 0 : (page - 1) * Common.Configuration.EntriesPerPage;
            List<T> list = this.Skip(index).Take(Common.Configuration.EntriesPerPage).ToList();
            for (int i = 0; i < list.Count; i++)
                sb.AppendLine($"{index + i + 1}  {list[i].Name}");

            return sb.ToString();
        }
    }
}
