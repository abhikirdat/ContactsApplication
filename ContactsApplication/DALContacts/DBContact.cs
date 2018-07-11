using StructuresContacts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALContacts
{
    public static class DBContact
    {
        //get all contacts list, stored procedure :sp_get_contact_L
        public static DataTable DBGetContactList()
        {
            DataTable dtContactList = new DataTable();
            SqlCommand objCommand = new SqlCommand("sp_get_contact_L");
            objCommand.CommandType = CommandType.StoredProcedure;

            dtContactList = DBInteraction.GetTable(ref objCommand);
            if (objCommand != null)
            {
                objCommand.Dispose();
            }
            return dtContactList;
        }

        //get contact by contact ID, stored procedure :sp_get_contact_by_id
        public static DataTable DBGetContactById(int ContactID)
        {
            DataTable dtContact = new DataTable();
            SqlCommand objCommand = new SqlCommand("sp_get_contact_by_id");
            objCommand.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;
            objCommand.CommandType = CommandType.StoredProcedure;

            dtContact = DBInteraction.GetTable(ref objCommand);
            if (objCommand != null)
            {
                objCommand.Dispose();
            }
            return dtContact;
        }

        //update contact by contact ID, stored procedure :sp_update_contact_U
        public static bool DBUpdateContact(clsContact Contact)
        {
            bool result = true;

            SqlCommand objCommand = new SqlCommand("sp_update_contact_U");
            objCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter prmContactID = new SqlParameter("@ContactID", SqlDbType.BigInt);
            prmContactID.Value = Contact.ContactId;
            objCommand.Parameters.Add(prmContactID);

            SqlParameter prmFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar);
            prmFirstName.Value = Contact.FirstName;
            objCommand.Parameters.Add(prmFirstName);

            SqlParameter prmLastName = new SqlParameter("@LastName", SqlDbType.VarChar);
            prmLastName.Value = Contact.LastName;
            objCommand.Parameters.Add(prmLastName);

            SqlParameter prmEmailID = new SqlParameter("@EmailID", SqlDbType.VarChar);
            prmEmailID.Value = Contact.EmailID;
            objCommand.Parameters.Add(prmEmailID);

            SqlParameter prmMobileNumber = new SqlParameter("@MobileNumber", SqlDbType.VarChar);
            prmMobileNumber.Value = Contact.MobileNumber;
            objCommand.Parameters.Add(prmMobileNumber);

            SqlParameter prmStatus = new SqlParameter("@Status", SqlDbType.Bit);
            prmStatus.Value = Contact.Status;
            objCommand.Parameters.Add(prmStatus);


            if (DBInteraction.ExecuteSQL(ref objCommand))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            if (objCommand != null)
            {
                objCommand.Dispose();
            }
            return result;

        }

        //Insert contact , stored procedure :sp_add_contact_I
        public static bool DBAddContact(clsContact Contact)
        {
            bool result = true;

            SqlCommand objCommand = new SqlCommand("sp_add_contact_I");
            objCommand.CommandType = CommandType.StoredProcedure;

            //SqlParameter prmContactID = new SqlParameter("@ContactID", SqlDbType.BigInt);
            //prmContactID.Direction = ParameterDirection.Output;
            //objCommand.Parameters.Add(prmContactID);

            SqlParameter prmFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar);
            prmFirstName.Value = Contact.FirstName;
            objCommand.Parameters.Add(prmFirstName);

            SqlParameter prmLastName = new SqlParameter("@LastName", SqlDbType.VarChar);
            prmLastName.Value = Contact.LastName;
            objCommand.Parameters.Add(prmLastName);

            SqlParameter prmEmailID = new SqlParameter("@EmailID", SqlDbType.VarChar);
            prmEmailID.Value = Contact.EmailID;
            objCommand.Parameters.Add(prmEmailID);

            SqlParameter prmMobileNumber = new SqlParameter("@MobileNumber", SqlDbType.VarChar);
            prmMobileNumber.Value = Contact.MobileNumber;
            objCommand.Parameters.Add(prmMobileNumber);

            SqlParameter prmStatus = new SqlParameter("@Status", SqlDbType.VarChar);
            prmStatus.Value = Contact.Status;
            objCommand.Parameters.Add(prmStatus);


            if (DBInteraction.ExecuteSQL(ref objCommand))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            if (objCommand != null)
            {
                objCommand.Dispose();
            }
            return result;

        }

        //Delete contact , stored procedure :sp_update_contact_D
        public static bool DBDeleteContact(int contactID)
        {
            bool result = true;

            SqlCommand objCommand = new SqlCommand("sp_update_contact_D");
            objCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter prmContactID = new SqlParameter("@ContactID", SqlDbType.BigInt);
            prmContactID.Value = contactID;
            objCommand.Parameters.Add(prmContactID);

            if (DBInteraction.ExecuteSQL(ref objCommand))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            if (objCommand != null)
            {
                objCommand.Dispose();
            }
            return result;

        }
    }
}
