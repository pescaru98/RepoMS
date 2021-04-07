using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OnlinePharmacy.XMLServices
{
    public class UserService
    {
        private string path = "C:\\Users\\Mihai\\Desktop\\RepoMS\\ForkIASS\\PharmaOnline\\OnlinePharmacy\\OnlinePharmacy\\XML\\user.xml";
        private XmlSerializer serializer;
        private TextReader reader;
        private TextWriter writer;

        public bool create(User user)
        {

            try
            {
                List<User> users = getAll();
                if (users == null)
                    users = new List<User>();

                users.Add(user);

                serializer =  new XmlSerializer(typeof(List<User>));
                writer = new StreamWriter(path);
                serializer.Serialize(writer, users);
                
                
                return true;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            finally
            {
                writer.Close();
            }
        }

        public List<User> getAll()
        {

                try
                {
                    List<User> list = new List<User>();

                    serializer = new XmlSerializer(typeof(List<User>));
                    reader = new StreamReader(path);

                    list = (List<User>)serializer.Deserialize(reader);


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
        public User getByUsernameAndPassword(string username, string password)
        {
            List<User> users = getAll();
            if (users == null)
                return null;

            List<User> foundUser = users.FindAll(us => us.username.Equals(username) && us.password.Equals(password));
            if (foundUser.Count != 0)
                return foundUser.ElementAt(0);
            return null;
        }

        public User getUserByGuid(Guid guid)
        {
            try
            {
                List<User> users = getAll();
                if (users == null || users.Count == 0)
                    return null;
                User foundUser = users.Find(user => user.user_id == guid);
                return foundUser;
            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }



        public bool updateCoinsAndBalanceOfUserId(Guid userId, double coins, double balance)
        {
            try
            {
                bool success = false;
                List<User> users = getAll();
                if (users == null || users.Count == 0)
                    return false;

                users.ForEach(user=>
                {
                    if(user.user_id.Equals(userId))
                    {
                        user.coins = coins;
                        user.balance = balance;
                        success = true;
                    }
                });

                serializer = new XmlSerializer(typeof(List<User>));
                writer = new StreamWriter(path);
                serializer.Serialize(writer, users);

                return success;
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
    }
 }
