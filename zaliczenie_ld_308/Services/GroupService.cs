using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using zaliczenie_ld_308.Entities;

namespace zaliczenie_ld_308.Services
{
    class GroupService : ServiceController, IService<Group>
    {
        public bool Create(Group group)
        {
            string query = "INSERT INTO `groups` (`name`) VALUES ('" + group.Name + "')";
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
        #region Get
        public Group Get(Group group)
        {
            string query = "SELECT id, name FROM `groups` WHERE name = '" + group.Name + "'";
            return this.ExecGet(query);
        }
        public Group Get(int id)
        {
            string query = "SELECT id, name FROM `groups` WHERE id = '" + id + "'";
            return this.ExecGet(query);
        }
        public Group Get(string name)
        {
            string query = "SELECT id, name FROM `groups` WHERE name = '" + name + "'";
            return this.ExecGet(query);
        }
        private Group ExecGet(string query)
        {
            Group group = new Group();
            MySqlDataReader reader = this.msa.ExecuteQuery(query);
            if (reader.HasRows == true)
            {
                reader.Read();
                group.Id = Int16.Parse(reader[0].ToString());
                group.Name = reader[1].ToString();
                reader.Close();
                return group;
            }
            else
            {
                return null;
            }
        }
        #endregion
        public List<Group> GetAll()
        {
            string query = "SELECT name FROM `groups`";
            MySqlDataReader reader = this.msa.ExecuteQuery(query);
            List<Group> groupList = new List<Group>();
            for (int l = 0; reader.Read() != false; l++)
            {
                Group group = new Group
                {
                    Name = reader[0].ToString()
                };

                groupList.Add(group);
            }
            reader.Close();

            return groupList;
        }
    }
}
