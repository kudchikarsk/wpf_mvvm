using Aasani.CRM.Data;
using Aasani.CRM.Logic;
using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aasani.CRM.App
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ContactService contactService;
        private ContactForm newContact;
        private List<ContactForm> contacts;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ContactForm NewContact
        {
            get => newContact;
            set
            {
                newContact = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(NewContact)));
            }
        }

        public List<ContactForm> Contacts 
        { 
            get => contacts; 
            set
            {
                contacts = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Contacts)));
            }
        }

        public ICommand AddContact { get; set; }

        public MainWindowViewModel()
        {
            contactService = new ContactService();
            NewContact = new ContactForm();
            AddContact = new AsyncCommand(ExecuteAddContact);
        }

        public async void OnLoad()
        {
            IEnumerable<Contact> contacts = await contactService.Paginate(_ => true);
            Contacts = contacts.Select(contact => new ContactForm
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Mobile = contact.Mobiles.FirstOrDefault(),
            }).ToList();
        }

        private async Task ExecuteAddContact()
        {
            Contact contact = await contactService.Add(new Contact
            {
                FirstName = NewContact.FirstName,
                LastName = NewContact.LastName,
                Mobiles = new List<string> { NewContact.Mobile },
            });
            Contacts = new List<ContactForm> { new ContactForm{
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Mobile = contact.Mobiles.FirstOrDefault(),

            } }
                            .Concat(Contacts)
                            .ToList();

            NewContact = new ContactForm();
        }
    }
}
