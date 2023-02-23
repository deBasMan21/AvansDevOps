using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public class ForumThreadComponent : ForumComponent
    {
        private List<ForumComponent> _children;

        public ForumThreadComponent(string message): base(message) => _children = new List<ForumComponent>();

        public override string GetComment() => _message + "\n\t" + string.Join("\n\t", _children.Select(c => c.GetComment()).ToList());

        public override void AddChild(ForumComponent component) => _children.Add(component);

        public override void RemoveChild(ForumComponent component) => _children.Remove(component);

        public override ForumComponent GetChild(int index) => _children[index];
    }
}
