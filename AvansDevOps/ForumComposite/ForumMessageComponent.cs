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
        private string message;
        private User creator;
        private ForumCompositeComponent? parent;
        public ForumMessageComponent(string message, User creator)
        {
            this.message = message;
            this.creator = creator;
        }

        public void SetParent(ForumCompositeComponent parent) => this.parent = parent;

        public void AddMessage(ForumMessageComponent component)
        {
            ForumThreadComponent thread = new ForumThreadComponent(this);
            thread.AddMessage(component);
            parent?.ReplaceChild(thread, this);
        }

        public List<ForumComponent> GetComponents() => new List<ForumComponent> { this };
    }
}
