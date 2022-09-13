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
    public class SkokDAOImpl : ISkokDAO
    {
        public int BVetarIzmena(string idSk, double bVetar)
        {
            string query = "update skok set bvetar=:bvetar where idsk=:idsk";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;                   
                    ParameterUtil.AddParameter(command, "bvetar", DbType.Double);
                    ParameterUtil.AddParameter(command, "idsk", DbType.String, 4);
                    command.Prepare();                    
                    ParameterUtil.SetParameterValue(command, "bvetar", bVetar);
                    ParameterUtil.SetParameterValue(command, "idsk", idSk);
         
                    return command.ExecuteNonQuery(); 
                }
            }
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Skok entity)
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

        public IEnumerable<Skok> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skok> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Skok FindById(string id)
        {
            string query = "select * from skok where idsk=:idsk";
            Skok skok = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idsk", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idsk", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            skok = new Skok(reader.GetString(0), reader.GetInt32(1),
                                reader.GetString(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5));

                        }
                    }
                }
            }

            return skok;
        }

        public int GetNumOfDiffSkakac(List<Skok> skokovi)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(distinct idsc) from skok where idsk in(");

            foreach (Skok skok in skokovi)
                sb.Append(":id" + skok.IdSk + ",");
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (Skok skok in skokovi)
                        ParameterUtil.AddParameter(command, "id" + skok.IdSk, DbType.String, 4);
                    command.Prepare();
                    foreach (Skok skok in skokovi)
                        ParameterUtil.SetParameterValue(command, "id" + skok.IdSk, skok.IdSk);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Skok> GetSkokByDrzava(List<int>skakaci, List<string>skakaonice)
        {
            throw new NotImplementedException();
        }

        public List<Skok> GetSkokBySkakaonica(string id)
        {
            List<Skok> ret = new List<Skok>();
            string query = "select * from skok where idsa = :id";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 6);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    using (IDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            ret.Add(new Skok(r.GetString(0), r.IsDBNull(1) ? 0 : r.GetInt32(1), r.IsDBNull(2) ? "" : r.GetString(2),
                                r.IsDBNull(3) ? 0 : r.GetDouble(3), r.IsDBNull(4) ? 0 : r.GetDouble(4),
                                r.IsDBNull(5) ? 0 : r.GetDouble(5)));
                        }
                    }
                }
            }
                    return ret;
        }

        public int Save(Skok entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Skok> entities)
        {
            throw new NotImplementedException();
        }
    }
}
