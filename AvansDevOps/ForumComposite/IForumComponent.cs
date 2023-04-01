using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public interface IForumComponent
    {
        List<IForumComponent> GetComponents();
        int AddMessage(ForumMessageComponent component);
        void CloseForum();
        string GetMessage();
    }
}
