using Projektni_Zadatak.Connection;
using Projektni_Zadatak.Model;
using Projektni_Zadatak.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_Zadatak.DAO.Implementarion
{
    public class DrzavaDAOImpl : IDrzavaDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Drzava entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drzava> FindAll()
        {
            string query = "select distinct * from drzava";
            List<Drzava> drzavaList = new List<Drzava>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Drzava drzava = new Drzava(reader.GetString(0), reader.GetString(1));
                            drzavaList.Add(drzava);
                        }
                    }
                }
            }

            return drzavaList;
        }

        public IEnumerable<Drzava> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Drzava FindById(string id)
        {
            throw new NotImplementedException();
        }

        public string NazivDrzavaById(string idd)
        {
            string query = "select nazivd from drzava where idd=:idd";
            string drzava = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idd", DbType.String, 6);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idd", idd);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            drzava = reader.GetString(0);
                        }
                    }
                }
            }

            return drzava;
        }

        public int Save(Drzava entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Drzava> entities)
        {
            throw new NotImplementedException();
        }
    }
}
