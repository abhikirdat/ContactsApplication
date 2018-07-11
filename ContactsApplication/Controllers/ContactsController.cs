using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsApplication.Models;
using DALContacts;
using BLCommon;
using System.Data;
using StructuresContacts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ContactsApplication.Controllers
{
    public class ContactsController : ApiController
    {
        /// <summary>
        /// Get all contact list 
        /// </summary>
        /// <returns>IEnumerable<ContactViewModel></returns>
        public IEnumerable<ContactViewModel> GetAll()
        {
            DataTable dtContacts = DBContact.DBGetContactList();
            
            List<ContactViewModel> lstContacts = dtContacts.ConvertDataTableToList<ContactViewModel>();

            return lstContacts;
        }
        
        /// <summary>
        /// Get contact list by id
        /// </summary>
        /// <param name="ContactID"></param>
        /// <returns>ContactViewModel: model class </returns>
        public ContactViewModel GetContactsByID(int ContactID)
        {
            DataTable dtContacts = DBContact.DBGetContactById(ContactID);
            ContactViewModel objcontact = null;

            var convertedList = (from rw in dtContacts.AsEnumerable()
                                 select new ContactViewModel()
                                 {
                                     ContactID = Convert.ToInt32(rw["ContactID"]),
                                     FirstName=Convert.ToString(rw["FirstName"]),
                                     LastName = Convert.ToString(rw["LastName"]),
                                     EmailID = Convert.ToString(rw["EmailID"]),
                                     MobileNumber = Convert.ToString(rw["MobileNumber"]),
                                     Status=Convert.ToBoolean(rw["Status"])
                                 }).FirstOrDefault();

           objcontact = convertedList;

            return objcontact;
        }

        /// <summary>
        /// update contacts by id using httppost
        /// </summary>
        /// <param name="stringContent"></param>
        /// <returns>bool</returns>
        [HttpPost]
        public bool updateContacts([FromBody]dynamic stringContent)
        {
            clsContact objContact = JsonConvert.DeserializeObject(stringContent, typeof(clsContact));
            return DBContact.DBUpdateContact(objContact);
        }

        /// <summary>
        /// add new contact to database using httpput
        /// </summary>
        /// <param name="contects"></param>
        /// <returns>bool</returns>
        [HttpPut]
        public bool addContacts([FromBody]dynamic contects)
        {
            clsContact objContact = JsonConvert.DeserializeObject(contects, typeof(clsContact));
            return DBContact.DBAddContact(objContact);
        }

        /// <summary>
        /// delete contact by id using httpdelete 
        /// </summary>
        /// <param name="ContactID"></param>
        /// <returns>bool</returns>
        [HttpDelete]
        public bool DeleteContactsByID(int ContactID)
        {
            return DBContact.DBDeleteContact(ContactID);
        }
    }
}
