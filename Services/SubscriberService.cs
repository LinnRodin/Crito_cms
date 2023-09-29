using Crito.Contexts;
using Crito.Entitys;
using Crito.Models;


namespace Crito.Services
{
    public class SubscriberService
    {
        private readonly DataContext _context;

        public SubscriberService(DataContext context)
        {
            _context = context;
        }


        public async Task AddSubscriberAsync(SubscribeModel form)
        {
            _context.Subscribers.Add(new SubscribeEntity { Email = form.Email });
            await _context.SaveChangesAsync();

        }
    }
}
