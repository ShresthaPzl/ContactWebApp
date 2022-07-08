using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IContactRepository
    {
        List<ContactModel> GetAllContact();
        int AddNewContact(ContactModel model);
        ContactModel GetContactById(int id);
        int ContactCount();
        ContactModel LastEmployee();
        ContactModel RandomContact();
        int UpdateContact(ContactModel model);
        int DeleteContact(int id);
    }
}
