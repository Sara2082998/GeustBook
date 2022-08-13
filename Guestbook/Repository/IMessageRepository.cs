using Guestbook.Models;
using System.Collections.Generic;

namespace Guestbook.Repository
{
    public interface IMessageRepository
    {
        public int Delete(int id);
        public int Insert( Message ms);
        public int Edit(int id, Message ms);
        public Message FindById(int id);
        public List<Message> getAll();
    }
}
