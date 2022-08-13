using Guestbook.Models;
using System.Collections.Generic;
using System.Linq;

namespace Guestbook.Repository
{
    public class MessageRepository:IMessageRepository
    {
        GeustDbcontext context;
        public MessageRepository(GeustDbcontext context)
        {
            this.context = context;
        }
        public List<Message>getAll()
        {
            return context.Messages.ToList();
        }
        public Message FindById(int id)
        {
            return context.Messages.FirstOrDefault(x => x.id == id);
        }
        public int Insert(Message message)
        {
            context.Messages.Add(message);
            int row = context.SaveChanges();
            return row;
        }
        public int Edit(int id , Message message)
        {
            Message msg = new Message();
            if (message != null)
            {
                msg.id = message.id;
                msg.text = message.text;
                int row = context.SaveChanges();
                return row;
            }
            return 0;

        }
        public int Delete(int id)
        {
            Message message = FindById(id);
            context.Messages.Remove(message);
            return context.SaveChanges();
        }
    }
}
