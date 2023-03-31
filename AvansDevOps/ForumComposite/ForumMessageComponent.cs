using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public class ForumMessageComponent : ForumComponent
    {
        private ForumCompositeComponent? parent;
        public string message { get; private set; }
        public User creator { get; private set; } 
        public ForumMessageComponent(string message, User creator)
        {
            this.message = message;
            this.creator = creator;
        }

        public void SetParent(ForumCompositeComponent parent) => this.parent = parent;

        public int AddMessage(ForumMessageComponent component)
        {
            ForumThreadComponent thread = new ForumThreadComponent(this);
            thread.AddMessage(component);
            parent?.ReplaceChild(thread, this);
            return 1;
        }

        public List<ForumComponent> GetComponents() => new List<ForumComponent> { this };
    }
}
