using System.Collections.Generic;
using System.Linq;
using System;

namespace Faktury.Biz
{
    public class DBManager
    {
        //Deleting owner profile
        public static void DeleteProfile(int selectedOwnerId)
        {
            using (var context = new FakturyContext())
            {
                var query = context.Owners
                    .Where(n => n.Id == selectedOwnerId)
                    .FirstOrDefault();

                context.Owners.Remove(query);
                context.SaveChanges();
            }
        }

        //Selecting data for ListView in OwnersManager
        public static List<Owner> DataForOwnersListView()
        {
            using (var context = new FakturyContext())
            {
                var query = context.Owners
                    .OrderBy(n => n.Id);
                var owners = query.ToList();
                return owners;
            }
        }

        //Deleting client profile
        public static void DeleteClient(int selectedClientId)
        {
            using (var context = new FakturyContext())
            {
                var query = context.Clients
                    .Where(n => n.Id == selectedClientId)
                    .FirstOrDefault();

                context.Clients.Remove(query);
                context.SaveChanges();
            }
        }

        //Selecting data for ListView in ClientsManager
        public static List<Client> DataForClientsListView()
        {
            using (var context = new FakturyContext())
            {
                var query = context.Clients
                    .OrderBy(n => n.Id);
                var clients = query.ToList();
                return clients;
            }
        }

        //Selecting first owner
        public static Owner SelectDefaultOwner()
        {
            using (var context = new FakturyContext())
            {
                var defaultOwner = context.Owners
                    .FirstOrDefault();
                return defaultOwner;
            }
        }

        //Selecting client by name
        public static Client ClientByName(string name)
        {
            using (var context = new FakturyContext())
            {
                var client = context.Clients
                    .Where(n => n.Name == name)
                    .FirstOrDefault();
                return client;
            }
        }

        //Selecting owner by name
        public static Owner OwnerByName(string name)
        {
            using (var context = new FakturyContext())
            {
                var owner = context.Owners
                    .Where(n => n.Name == name)
                    .FirstOrDefault();
                return owner;
            }
        }

        //Adding client to DB
        public static void AddClient(Client client)
        {
            using (var context = new FakturyContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        //Adding owner to DB
        public static void AddOwner(Owner owner)
        {
            using (var context = new FakturyContext())
            {
                context.Owners.Add(owner);
                context.SaveChanges();
            }
        }

        //Editing client data
        public static void EditClientData(int id, string name, string address, string city, string postcode, string nip)
        {
            using (var context = new FakturyContext())
            {
                var client = context.Clients
                    .Where(n => n.Id == id)
                    .FirstOrDefault();
                client.Name = name;
                client.Address = address;
                client.City = city;
                client.PostCode = postcode;
                client.NIP = nip;
                context.SaveChanges();
            }
        }

        //Editing owner data
        public static void EditOwnerData(int id, string name, string address, string city, string postcode, string nip)
        {
            using (var context = new FakturyContext())
            {
                var owner = context.Owners
                    .Where(n => n.Id == id)
                    .FirstOrDefault();
                owner.Name = name;
                owner.Address = address;
                owner.City = city;
                owner.PostCode = postcode;
                owner.NIP = nip;
                context.SaveChanges();
            }
        }

        //Searching client
        public static List<Client> SearchClient(string querystring)
        {
            using (var context = new FakturyContext())
            {
                var query = context.Clients
                    .Where(n => n.Name.Contains(querystring) || n.Address.Contains(querystring) || n.City.Contains(querystring) 
                        || n.PostCode.Contains(querystring) || n.NIP.Contains(querystring));
                    
                var clients = query.ToList();
                return clients;
            }           
        }

        //Searching owner
        public static List<Owner> SearchOwner(string querystring)
        {
            using (var context = new FakturyContext())
            {
                var query = context.Owners
                    .Where(n => n.Name.Contains(querystring) || n.Address.Contains(querystring) || n.City.Contains(querystring)
                        || n.PostCode.Contains(querystring) || n.NIP.Contains(querystring));

                var owners = query.ToList();
                return owners;
            }
        }

        //Saving invoice
        public static void SaveInvoice(Invoice invoiceToSave)
        {
            using (var context = new FakturyContext())
            {
                var client = context.Clients
                    .Where(n => n.NIP == invoiceToSave.Client.NIP)
                    .First();

                var owner = context.Owners
                    .Where(n => n.NIP == invoiceToSave.Owner.NIP)
                    .First();
                Invoice invoice = new Invoice(invoiceToSave.Date, invoiceToSave.NumberOfInvoice, client, owner, invoiceToSave.products);

                context.Invoices.Add(invoice);
                context.SaveChanges();
            }
        }

        //Retrieving data for InvoiceListView
        public static List<Invoice> DataForInvoiceListView(int id)
        {
            using (var context = new FakturyContext())
            {
                var query = context.Invoices
                    .Where(n => n.Owner.Id == id)
                    .OrderBy(n => n.Date);
                var clients = query.ToList();
                return clients;
            }
        }

        //Retrieving cline by id
        public static string ClientById(int id)
        {
            using (var context = new FakturyContext())
            {
                var client = context.Clients
                    .Where(n => n.Id == id)
                    .FirstOrDefault();
                return client.Name;
            }
        }

        //Deleting invoice
        public static void DeleteInvoice(int selectedInvoiceId)
        {
            using (var context = new FakturyContext())
            {
                var query = context.Invoices
                    .Where(n => n.Id == selectedInvoiceId)
                    .FirstOrDefault();

                context.Invoices.Remove(query);
                context.SaveChanges();
            }
        }

        public void AddProduct(int productId, string name, decimal vat, decimal quantity, decimal price, bool netto, List<Product> products)
        {
            products.Add(new Product(productId, name, vat, quantity, price, netto));
        }
         
    }
}
