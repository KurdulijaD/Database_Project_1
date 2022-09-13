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
    public class SkakaonicaDAOImpl : ISkakaonicaDAO
    {
        public int Count()
        {
            string query = "select count(*) from skakaonica";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Delete(Skakaonica entity)
        {
            return DeleteById(entity.IdSa);
        }

        public int DeleteAll()
        {
            string query = "delete from skakaonica";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteById(string id)
        {
            string query = "delete from skakaonica where idSa=:idSa";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idSa", DbType.String, 6);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idSa", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(string id)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(string id, IDbConnection connection)
        {
            string query = "select * from skakaonica where idSa=:idSa";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "idSa", DbType.String, 6);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idSa", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Skakaonica> FindAll()
        {
            string query = "select * from skakaonica";
            List<Skakaonica> skakaonicaList = new List<Skakaonica>();

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
                            Skakaonica skakaonica = new Skakaonica(reader.GetString(0), reader.GetString(1),
                                reader.IsDBNull(2) ? 0 : reader.GetInt32(2), reader.IsDBNull(3) ? "" : reader.GetString(3), reader.GetString(4));
                            skakaonicaList.Add(skakaonica);
                        }
                    }
                }
            }

            return skakaonicaList;
        }

        public IEnumerable<Skakaonica> FindAllById(IEnumerable<string> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from skakaonica where idSa in(");
            foreach (string id in ids)
            {
                sb.Append(":idSa" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            List<Skakaonica> skakaonicaList = new List<Skakaonica>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (string id in ids)
                    {
                        ParameterUtil.AddParameter(command, "id" + id, DbType.String, 6);
                    }
                    command.Prepare();

                    foreach (string id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "id" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakaonica skakaonica = new Skakaonica(reader.GetString(0), reader.GetString(1),
                                reader.IsDBNull(2) ? 0 : reader.GetInt32(2), reader.IsDBNull(3) ? "" : reader.GetString(3), reader.GetString(4));
                            skakaonicaList.Add(skakaonica);
                        }
                    }
                }
            }

            return skakaonicaList;
        }

        public Skakaonica FindById(string id)
        {
            string query = "select * from skakaonica where idsa=:idsa";
            Skakaonica skakaonica = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idsa", DbType.String, 6);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idsa", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             skakaonica = new Skakaonica(reader.GetString(0), reader.GetString(1),
                                reader.IsDBNull(2) ? 0 : reader.GetInt32(2), reader.IsDBNull(3) ? "" : reader.GetString(3), reader.GetString(4));
                        }
                    }
                }
            }

            return skakaonica;
        }

        public int Save(Skakaonica entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(Skakaonica skakaonica, IDbConnection connection)
        {
            string insert = "insert into skakaonica (nazivsa, duzinasa, tipsa, idd, idsa) " +
                "values(:nazivsa, :duzinasa, :tipsa, :idd, :idsa)";
            string update = "update skakaonica set nazivsa = :nazivsa, duzinasa = :duzinasa," +
                "tipsa = :tipsa, idd = :idd where idsa = :idsa";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(skakaonica.IdSa, connection) ? update : insert;

                ParameterUtil.AddParameter(command, "nazivsa", DbType.String, 35);
                ParameterUtil.AddParameter(command, "duzinasa", DbType.Int32);
                ParameterUtil.AddParameter(command, "tipsa", DbType.String, 10);
                ParameterUtil.AddParameter(command, "idd", DbType.String, 3);
                ParameterUtil.AddParameter(command, "idsa", DbType.String, 6);
                command.Prepare();

                ParameterUtil.SetParameterValue(command, "nazivsa", skakaonica.NazivSa);
                ParameterUtil.SetParameterValue(command, "duzinasa", skakaonica.DuzinaSa);
                ParameterUtil.SetParameterValue(command, "tipsa", skakaonica.TipSa);
                ParameterUtil.SetParameterValue(command, "idd", skakaonica.IdD);
                ParameterUtil.SetParameterValue(command, "idsa", skakaonica.IdSa);

                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<Skakaonica> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction(); // transaction start

                int numSaved = 0;

                // insert or update every theatre
                foreach (Skakaonica entity in entities)
                {
                    // changes are visible only to current connection
                    numSaved += Save(entity, connection);
                }

                // transaction ends successfully, changes are now visible to other connections as well
                transaction.Commit();

                return numSaved;
            }
        }

        public List<string> GetSkakaoniceFromDrzava(string id)
        {
            List<string> ret = new List<string>();
            string query = "select idsa from skakaonica where idd = :id";
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
                            ret.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return ret;
        }

        public List<Skakaonica> DuzineSkakaonicaOpseg(int min, int max)
        {
            List<Skakaonica> skakaonice = new List<Skakaonica>();
            string query = "select * from skakaonica where duzinasa between :min and :max";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "min", DbType.Int32);
                    ParameterUtil.AddParameter(command, "max", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "min", min);
                    ParameterUtil.SetParameterValue(command, "max", max);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            skakaonice.Add(new Skakaonica(reader.GetString(0), reader.GetString(1),
                                reader.IsDBNull(2) ? 0 : reader.GetInt32(2), reader.IsDBNull(3) ? "" : reader.GetString(3), reader.GetString(4)));
                        }
                    }
                }
            }

            return skakaonice;
        }
    }
}
