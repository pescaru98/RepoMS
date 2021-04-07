using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OnlinePharmacy.XMLServices
{
    public class TransactionService
    {
        private string path = "C:\\Users\\Mihai\\Desktop\\RepoMS\\ForkIASS\\PharmaOnline\\OnlinePharmacy\\OnlinePharmacy\\XML\\transaction.xml";
        private XmlSerializer serializer;
        private TextReader reader;
        private TextWriter writer;

        public bool create(Transaction transaction)
        {

            try
            {
                List<Transaction> transactions = getAll();
                if (transactions == null)
                    transactions = new List<Transaction>();

                transactions.Add(transaction);

                serializer = new XmlSerializer(typeof(List<Transaction>));
                writer = new StreamWriter(path);
                serializer.Serialize(writer, transactions);


                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            finally
            {
                writer.Close();
            }
        }

        public List<Transaction> getAll()
        {

            try
            {
                List<Transaction> list = new List<Transaction>();

                serializer = new XmlSerializer(typeof(List<Transaction>));
                reader = new StreamReader(path);

                list = (List<Transaction>)serializer.Deserialize(reader);


                return list;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;

            }
            finally
            {
                reader.Close();
            }
        }

        public List<Transaction> getTransactionsOfUserId(Guid userId)
        {
            try
            {
                List<Transaction> transactions = getAll();
                if (transactions == null || transactions.Count == 0)
                    return null;

                List<Transaction> myTransactions = transactions.FindAll(item => item.buyer_id.Equals(userId) || item.seller_id.Equals(userId)).ToList();

                return myTransactions;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}