using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public interface ForumComponent
    {
        List<ForumComponent> GetComponents();
        int AddMessage(ForumMessageComponent component);
    }
}
