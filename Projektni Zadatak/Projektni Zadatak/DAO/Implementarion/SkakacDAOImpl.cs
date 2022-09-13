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
    public class SkakacDAOImpl : ISkakacDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Skakac entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skakac> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skakac> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Skakac FindById(int id)
        {
            string query = "select * from skakac where idsc=:idsc";
            Skakac skakac = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idsc", DbType.String, 6);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idsc", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            skakac = new Skakac(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), 
                                reader.IsDBNull(4) ? 0 : reader.GetInt32(4), reader.IsDBNull(5) ? 0 : reader.GetInt32(5));
                        }
                    }
                }
            }

            return skakac;
        }

        public double GetPbsc(int idSc)
        {
            string query = "select pbsc from skakac where idsc=:idsc";
            double pbsc = 0;
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idsc", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idsc", idSc);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pbsc = reader.GetDouble(0);
                        }
                    }
                }
            }
            return pbsc;
        }

        public List<int> GetSkakaciFromDrzava(string id)
        {
            List<int> ret = new List<int>();
            string query = "select idsc from skakaonica where idd = :id";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 3);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ret.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            return ret;
        }

        public int PbscIzmena(int idSc, double pbsc)
        {
            string query = "update skakac set pbsc=:pbsc where idsc=:idsc";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pbsc", DbType.Double);
                    ParameterUtil.AddParameter(command, "idsc", DbType.Int32);                   
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pbsc", pbsc);
                    ParameterUtil.SetParameterValue(command, "idsc", idSc);                    

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int Save(Skakac entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Skakac> entities)
        {
            throw new NotImplementedException();
        }
    }
}
