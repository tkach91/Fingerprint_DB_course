using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using System.Diagnostics;

namespace Enrollment
{
    class dbhandler
    {

        private string conn_str;

        public dbhandler()
        {
            conn_str = "Server=;Port=5432;User Id=pgadmin; Password=;Database=curproj;";
        }

        // проверяем, можно ли вообще дальше работать, если да - возвращаем id
        public Int32 compare(string emp_name, string emp_pass)
        {
            NpgsqlConnection conn = new NpgsqlConnection(conn_str);
            try
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("select * from employees where emp_login = @ename", conn);
                com.Parameters.Add(new NpgsqlParameter("ename", NpgsqlDbType.Varchar));
                com.Parameters[0].Value = emp_name;
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Int32 result = reader.GetInt32(0);
                        if (reader.GetString(2) == hashing.useMD5(emp_pass))
                            return result;
                        else
                            return -1;
                    }
                    catch { }

                }
                conn.Close();
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }
            return 0;
        }

        // получаем id по имени
        public Int32 GetIdByName(string emp_name)
        {
            NpgsqlConnection conn = new NpgsqlConnection(conn_str);
            try
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("select * from employees where emp_login = @ename", conn);
                com.Parameters.Add(new NpgsqlParameter("ename", NpgsqlDbType.Varchar));
                com.Parameters[0].Value = emp_name;
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        return reader.GetInt32(0);
                    }
                    catch { }

                }
                conn.Close();
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }
            return 0;
        }

        // Получаем айдишники всех имеющихся отпечатков для пользователя с данным id
        public Int32[] GetDactIDs(Int32 emp_id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(conn_str);
            Int32[] result = new Int32[10];
            try
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("select * from fingers where fing_emp_id = @id", conn);
                com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Integer));
                com.Parameters[0].Value = emp_id;
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    result[i] = reader.GetInt32(3);
                    i++;
                }
                conn.Close();
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }
            return result;
        }

        // Получаем айдишники всех имеющихся отпечатков для всех пользователей
        public Int32[] GetAllDactIDs()
        {
            NpgsqlConnection conn = new NpgsqlConnection(conn_str);
            Int32[] result = new Int32[1000];
            try
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("select * from fingers", conn);
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    result[i] = reader.GetInt32(3);
                    i++;
                }
                conn.Close();
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }
            return result;
        }

        public Int32 GetIdByDactId(Int32 dact_id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(conn_str);
            Int32 result = 0;
            try
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("select * from fingers where fing_dactil = @id", conn);
                com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Integer));
                com.Parameters[0].Value = dact_id;
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(1);
                }
                conn.Close();
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }
            return result;
        }


        // получаем нашу строчку отпечатка, передав id записи
        public string GetDact(Int32 id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(conn_str);
            try
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("select * from dactilos where dacti_id = @id", conn);
                com.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Integer));
                com.Parameters[0].Value = id;
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();
                string result;
                while (reader.Read())
                {
                    result = reader.GetString(1);
                    return result;
                }
                conn.Close();
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }
            return "";
        }

        // записываем информацию о пальце
        public void InsertFinger(Int32 emp_id, Int32 number, Int32 dactil_id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(conn_str);
            try
            {
                conn.Open();
                NpgsqlCommand query = new NpgsqlCommand("insert into fingers(fing_emp_id, fing_number, fing_dactil) values(@fei, @fn, @fd);", conn);
                query.Parameters.Add(new NpgsqlParameter("@fei", NpgsqlDbType.Integer));
                query.Parameters.Add(new NpgsqlParameter("@fn", NpgsqlDbType.Integer));
                query.Parameters.Add(new NpgsqlParameter("@fd", NpgsqlDbType.Integer));
                query.Parameters[0].Value = emp_id;
                query.Parameters[1].Value = number;
                query.Parameters[2].Value = dactil_id;
                Object res = query.ExecuteScalar();
                conn.Close();
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }
        }

        // записываем наш отпечаток
        public Int32 InsertFingSample(byte[] arr)
        {
            string str = ByteConvert.ByteArrayToString(arr);
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(conn_str);
                conn.Open();
                NpgsqlCommand query = new NpgsqlCommand("insert into dactilos(dacti_photo) values(@f) RETURNING dacti_id;", conn);
                query.Parameters.Add(new NpgsqlParameter("@f", NpgsqlDbType.Text));
                query.Parameters[0].Value = str;
                Object res = query.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(res);
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }           
        }

        // Сохраняем хеш в базе для одноразовой авторизации
        public string insertMD5HASH(Int32 emp_id)
        {
            Random Rand = new Random();
            int i = Rand.Next();
            string work = hashing.useMD5(i.ToString());
            NpgsqlConnection conn = new NpgsqlConnection(conn_str);
            try
            {
                conn.Open();
                NpgsqlCommand query = new NpgsqlCommand("insert into emp_hashes(emp_h_id, hash) values(@id, @hdata)", conn);
                query.Parameters.Add(new NpgsqlParameter("@hdata", NpgsqlDbType.Text));
                query.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Integer));
                query.Parameters[0].Value = work;
                query.Parameters[1].Value = emp_id;
                Object res = query.ExecuteScalar();
                conn.Close();
            }
            catch (NpgsqlException)
            {
                throw new Exception("Ошибка подключения к базе данных.");
            }
            catch
            {
                throw new Exception("Неизвестная ошибка.");
            }
            return work;
        }
    }
}
