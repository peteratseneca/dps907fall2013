using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace SecurityUsingOAuth.ViewModels
{
    public class Repo_Credential : RepositoryBase
    {
        // Get ALL items
        public IEnumerable<CredentialFull> GetCredentials()
        {
            return Mapper.Map<IEnumerable<CredentialFull>>
                (ds.Credentials.OrderBy(o => o.Username));
        }

        // Get specific item
        public CredentialFull GetCredentialById(int id)
        {
            var credential = ds.Credentials.Find(id);
            
            return (credential == null) ? null : Mapper.Map<CredentialFull>(credential);
        }

        // Get specific item
        // Enables lookup by username and password
        public CredentialFull GetCredentialByValues(string username, string password)
        {
            // Clean the incoming username
            username = username.Trim().ToLower();
            
            // Attempt to locate the credential
            var credential = ds.Credentials.SingleOrDefault
                (u => u.Username == username && u.Password == password);

            return (credential == null) ? null : Mapper.Map<CredentialFull>(credential);
        }

        // Add item
        public CredentialFull AddCredential(CredentialAdd credential)
        {
            // Map from view model
            var c = ds.Credentials.Add(Mapper.Map<Models.Credential>(credential));

            // Create the HTTP Basic Authentication encoding
            byte[] bytesToEncode =
                System.Text.Encoding.ASCII.GetBytes
                (c.Username.Trim().ToLower() + ":" + c.Password);
            c.Token = System.Convert.ToBase64String(bytesToEncode);
            
            ds.SaveChanges();

            return Mapper.Map<CredentialFull>(c);
        }

        // Delete item
        public CredentialFull DeleteCredential(int id)
        {
            var credential = ds.Credentials.Find(id);

            if (credential == null)
            {
                return null;
            }
            else
            {
                ds.Credentials.Remove(credential);
                ds.SaveChanges();
                return Mapper.Map<CredentialFull>(credential);
            }
        }

    }
}
