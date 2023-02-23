using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public class ForumCommentComponent: ForumComponent
    {
        public ForumCommentComponent(string message): base(message) { }

        public override string GetComment() => _message;
    }
}
