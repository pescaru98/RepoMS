using OnlinePharmacy.XMLModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OnlinePharmacy.XMLServices
{
    public class GitCoinService
    {
        private string path = "C:\\Users\\Mihai\\Desktop\\RepoMS\\ForkIASS\\PharmaOnline\\OnlinePharmacy\\OnlinePharmacy\\XML\\gitcoinrecord.xml";
        private XmlSerializer serializer;
        private TextReader reader;
        private TextWriter writer;


        public bool create(GitCoinRecord gitCoinRecord)
        {

            try
            {
                List<GitCoinRecord> records = getAll();
                if (records == null)
                    records = new List<GitCoinRecord>();

                records.Add(gitCoinRecord);

                serializer = new XmlSerializer(typeof(List<GitCoinRecord>));
                writer = new StreamWriter(path);
                serializer.Serialize(writer, records);


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

        public List<GitCoinRecord> getAll()
        {

            try
            {
                List<GitCoinRecord> list = new List<GitCoinRecord>();

                serializer = new XmlSerializer(typeof(List<GitCoinRecord>));
                reader = new StreamReader(path);

                list = (List<GitCoinRecord>)serializer.Deserialize(reader);


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

        public double getCurrentGitCoinValue()
        {
            List<GitCoinRecord> list = getAll();
            List<GitCoinRecord> sortedListByDate = list.OrderBy(item => item.record_date).ToList();

            return sortedListByDate.ElementAt(sortedListByDate.Count - 1).price;
        }

        public double calculateNextCoinValue(double coinsSoldOrBought, double current_price, int sell_or_buy)
        {
            
            if(sell_or_buy == 1)
            {
                //sold
                return current_price - coinsSoldOrBought * 0.005;
            }
            else
            {

                //bought
                return current_price + coinsSoldOrBought * 0.005;
            }
        }
    }
}