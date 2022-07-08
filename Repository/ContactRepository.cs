using Models;
using System;
using System.Collections.Generic;
using Services;
using Data;
using Data.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public int AddNewContact(ContactModel model)
        {
            var contact = new Contacts()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Relation = model.Relation
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact.Id;
        }

        public List<ContactModel> GetAllContact()
        {
            return _context.Contacts.Select(
                x => new ContactModel() {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Relation = x.Relation

                }).ToList();
        }

        public ContactModel GetContactById(int id)
        {
            return _context.Contacts.Where(x => x.Id == id)
                .Select(contact => new ContactModel() {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    MiddleName = contact.MiddleName,
                    LastName = contact.LastName,
                    PhoneNumber = contact.PhoneNumber,
                    Email = contact.Email,
                    Relation = contact.Relation
                }).FirstOrDefault();

        }

        public int UpdateContact(ContactModel model)
        {
            var contact = new Contacts()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Relation = model.Relation
            };

            _context.Contacts.Update(contact);
            _context.SaveChanges();

            return contact.Id;
        }

        public int DeleteContact(int id)
        {
            var contact = _context.Contacts.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(contact);
            _context.SaveChanges();
            return contact.Id;
        }
        public int ContactCount()
        {
            return _context.Contacts.Count();
        }

        public ContactModel LastEmployee()
        {
            var contact = _context.Contacts.OrderByDescending(x => x.Id)
                .Select(x => new ContactModel() { 
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).FirstOrDefault();

            return contact;
        }

        public ContactModel RandomContact()
        {
            var random = new Random();
           var contacts = _context.Contacts.Select(
                x => new ContactModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Relation = x.Relation

                }).ToList();

            return contacts.OrderBy(x => random.Next()).Take(1)
                .Select(x => new ContactModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).FirstOrDefault();
        }

        public async Task<List<ContactModel>> SearchContact(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var contacts = await _context.Contacts.ToListAsync();
                var data = contacts.Where(a => a.FirstName.Contains(term, StringComparison.OrdinalIgnoreCase)
                || a.LastName.Contains(term, StringComparison.OrdinalIgnoreCase)
                || a.MiddleName.Contains(term, StringComparison.OrdinalIgnoreCase))
                    .Select( x=> new ContactModel() { 
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        MiddleName = x.MiddleName,
                        Relation = x.Relation,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber
                    }).ToList();
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}
