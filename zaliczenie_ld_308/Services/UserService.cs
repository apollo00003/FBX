using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using zaliczenie_ld_308.Entities;
using zaliczenie_ld_308.Utilities;

namespace zaliczenie_ld_308.Services
{
    class UserService : ServiceController, IService<User>
    {
        /**
         * Param User
         * Return bool
         */
        public bool Create(User user)
        {
            user.Password = Security.Hash(user.Password);
            string query = "INSERT INTO `users` (`username`, `email`, `password`) VALUES ('" + user.Username + "','" + user.Email + "','" + user.Password + "')";
            try
            {
                this.msa.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /**
         * Param User
         * Return User|null
         */
        #region Get
        public User Get(User user)
        {
            string query = "SELECT id, username, email, password FROM `users` WHERE username = '" + user.Username + "'";
            return this.GetExec(query);
        }
        public User Get(int id)
        {
            string query = "SELECT id, username, email, password FROM `users` WHERE id = '" + id + "'";
            return this.GetExec(query);
        }
        public User Get(string username)
        {
            string query = "SELECT id, username, email, password FROM `users` WHERE username = '" + username + "'";
            return this.GetExec(query);
        }
        private User GetExec(string query)
        {
            User user = new User();
            MySqlDataReader reader = this.msa.ExecuteQuery(query);
            if (reader.HasRows == true)
            {
                reader.Read();
                user.Id = Int16.Parse(reader[0].ToString());
                user.Username = reader[1].ToString();
                user.Email = reader[2].ToString();
                user.Password = reader[3].ToString();
                reader.Close();
                user.GroupList = this.GetUserGroupsList(user);

                return user;
            }
            else
            {
                reader.Close();
                return null;
            }
        } 
        #endregion
        /**
         * Param empty
         * Return List<Users>
         */
        public List<User> GetAll()
        {
            string query = "SELECT username FROM `users`";
            MySqlDataReader reader = this.msa.ExecuteQuery(query);
            List<User> usersList = new List<User>();
            for (int l = 0; reader.Read() != false; l++)
            {
                User user = new User
                {
                    Username = reader[0].ToString()
                };
                usersList.Add(user);
            }
            reader.Close();

            return usersList;
        }
        public bool AddUserToGroup(User user, Group group)
        {
            GroupService groupService = new GroupService();
            if ((user = this.Get(user)) == null) //Użytkownik nie istnieje
            {
                return false;
            }
            if ((group = groupService.Get(group)) == null) //Grupa nie istnieje
            {
                return false;
            }

            string query = "INSERT INTO `user_group` (`id_user`, `id_group`) VALUES ('" + user.Id + "', '" + group.Id + "')";
            Console.WriteLine(query);
            return this.msa.ExecuteNonQuery(query);
        }
        public List<Group> GetUserGroupsList(User user)
        {
            List<Group> groupList = new List<Group>();
            string query = "SELECT `id_group` FROM `user_group` WHERE id_user = " + user.Id;
            MySqlDataReader reader = this.msa.ExecuteQuery(query);
            if (reader.HasRows == true)
            {
                //Pozyskanie id wszystkich grup
                for (int l = 0; reader.Read() != false; l++)
                {
                    Group group = new Group
                    {
                        Id = Int16.Parse(reader[0].ToString())
                    };
                    groupList.Add(group);
                }
                reader.Close();

                //Pozyskanie grup po wczesniej wygenerowanych ID's
                query = "SELECT `id`, `name` FROM groups WHERE id = ";
                string subQuery = null;
                for (int l = 0; l < groupList.Count; l++)
                {
                    if (l > 0)
                    {
                        subQuery += " OR id = " + groupList[l].Id;
                    }
                    else
                    {
                        subQuery += groupList[l].Id;
                    }
                }
                query += subQuery;
                reader = this.msa.ExecuteQuery(query);

                groupList = new List<Group>();
                for (int l = 0; reader.Read() != false; l++)
                {
                    Group group = new Group
                    {
                        Id = Int16.Parse(reader[0].ToString()),
                        Name = reader[1].ToString()
                    };
                    groupList.Add(group);
                }
                reader.Close();
                return groupList;
            }
            else
            {
                return null;
            }
        }
    }
}
