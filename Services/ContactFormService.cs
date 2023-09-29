using Crito.Contexts;
using Crito.Entitys;
using Crito.Models;

namespace Crito.Services
{
    public class ContactFormService
    {
        private readonly DataContext _context;

        public ContactFormService(DataContext context)
        {
            _context = context;
        }

        public async Task AddContactAsync(ContactForm formModel)
        {   

            _context.ContactForms.Add(new ContactFormEntity

            {   
                Id = Guid.NewGuid(),
                Name = formModel.Name,
                Email = formModel.Email,
                Message = formModel.Message
               

            });
              await _context.SaveChangesAsync();

        }

        public ContactFormEntity GetContactFormById(Guid id)
        {
            return _context.ContactForms.FirstOrDefault(formModel => formModel.Id == id)!;
        }

    }
}
