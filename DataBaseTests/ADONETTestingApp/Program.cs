using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADONETTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeesDB;Integrated Security=True;";

            //DbConnectionStringBuilder sb = new DbConnectionStringBuilder() { ConnectionString = connection_string };

            //SqlConnectionStringBuilder sql_sb = new SqlConnectionStringBuilder(connection_string);
            //sql_sb.DataSource = "(localdb)\\MSSQLLocalDB";
            //sql_sb.InitialCatalog = "TestDB";
            //sql_sb.IntegratedSecurity = false;
            //sql_sb.UserID = "Login";
            //sql_sb.Password = "Pass";

            //var new_connection_string = sql_sb.ConnectionString;

            var connection_string = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //ExecuteNonQuery(connection_string);
            //ExecuteScalar(connection_string);
            //ExecuteReader(connection_string);
            //ParametricQuery(connection_string);
            DataAdapterTest(connection_string);

            Console.ReadLine();
        }


        private const string __SqlCreateTable = @"CREATE TABLE[dbo].[People] 
(
    [Id] INT IDENTITY(1, 1) NOT NULL,
    [Name] NVARCHAR(MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
    [Birthday] NVARCHAR(MAX) NULL,
    [Email]    NVARCHAR(100) NULL,
    [Phone]    NVARCHAR(MAX) NULL,
    CONSTRAINT[PK_dbo.People] PRIMARY KEY CLUSTERED([Id] ASC)
);";

        private const string __SqlInsertToPeopleTable = @"INSERT INTO [dbo].[People] (Name,Birthday,Email,Phone) VALUES (N'{0}','{1}','{2}','{3}');";

        private static void ExecuteNonQuery(string ConnactionString)
        {
            using (var connection = new SqlConnection(ConnactionString))
            {
                connection.Open();

                //var create_table_command = new SqlCommand(__SqlCreateTable, connection);
                //create_table_command.ExecuteNonQuery();

                var insert_data_command = new SqlCommand(
                    string.Format(__SqlInsertToPeopleTable,
                        "Иванов Иван Иванович",
                        "18.10.2001",
                        "ivanov@server.ru",
                        "+7(123)456-78-90"),
                    connection);
                insert_data_command.ExecuteNonQuery();
            }

        }

        private static string __SqlCountPeoples = @"SELECT COUNT(*) FROM [dbo].[People]";

        private static void ExecuteScalar(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var count_command = new SqlCommand(__SqlCountPeoples, connection);
                if (!(count_command.ExecuteScalar() is int count))
                    throw new InvalidOperationException("Ошибка результата команды - не является целым числом");
            }
        }

        private const string __SqlSelectFromPeople = @"SELECT * FROM [dbo].[People]";

        private static void ExecuteReader(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var select_command = new SqlCommand(__SqlSelectFromPeople, connection);
                using (var reader = select_command.ExecuteReader(CommandBehavior.Default))
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            var id = (int)reader.GetValue(0);
                            var name = reader.GetString(1);
                            var email = reader["Email"] as string;
                            var phone = reader.GetString(reader.GetOrdinal("Phone"));

                            Console.WriteLine("id:{0}\tname:{1}\temail:{2}\tphone:{3}", id, name, email, phone);
                        }
            }
        }

        private const string __SqlSelectWithFilter = @"SELECT COUNT(*) FROM [dbo].[People] WHERE {0}";

        private static void ParametricQuery(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var select_command = new SqlCommand(
                    string.Format(__SqlSelectWithFilter, "Birthday=@Birthday"),
                    connection);

                var birthday = new SqlParameter(
                    "@Birthday",
                    SqlDbType.NVarChar,
                    -1);

                select_command.Parameters.Add(birthday);

                birthday.Value = "18.10.2001";

                var count = (int)select_command.ExecuteScalar();
            }
        }

        private static void DataAdapterTest(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                //connection.Open();

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM People", connection);

                var table = new DataTable();

                adapter.Fill(table);
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                //connection.Open();

                var adapter = new SqlDataAdapter("SELECT * FROM People; SELECT * FROM Departament", connection);
                //var table = new DataTable();
                //adapter.Fill(table);

                var data_set = new DataSet();
                adapter.Fill(data_set);

                var peoples = data_set.Tables[0];
                var departaments = data_set.Tables[1];

                foreach (DataRow people in peoples.Rows) 
                    Console.WriteLine(people["Name"]);
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                //connection.Open();

                var adapter = new SqlDataAdapter("SELECT * FROM People", connection);

                var insert_command = new SqlCommand(@"INSERT INTO People (Name,Birthday,Email,Phone) VALUES (@Name,@Birthday,@Email,@Phone); SET @ID=@@IDENTITY", connection)
                {
                    Parameters =
                    {
                        { "@Name", SqlDbType.NVarChar, -1, "Name" },
                        { "@Birthday", SqlDbType.NVarChar, -1, "Birthday" },
                        { "@Email", SqlDbType.NVarChar, 100, "Email" },
                        { "@Phone", SqlDbType.NVarChar, -1, "Phone" },
                        { "@ID", SqlDbType.Int, 0, "ID" },
                    }
                };
                insert_command.Parameters["@ID"].Direction = ParameterDirection.Output;

                adapter.InsertCommand = insert_command;
                adapter.UpdateCommand = new SqlCommand(@"UPDATE People SET Name=@Name,Birthday=@Birthday WHERE ID=@ID", connection)
                {
                    Parameters =
                    {
                        { "@Name", SqlDbType.NVarChar, -1, "Name" },
                        { "@Birthday", SqlDbType.NVarChar, -1, "Birthday" },
                        { "@ID", SqlDbType.Int, 0, "ID" },
                    }
                };
                adapter.UpdateCommand.Parameters["@ID"].Direction = ParameterDirection.Output;

                adapter.DeleteCommand = new SqlCommand(@"DELETE FROM People WHERE ID=@ID", connection)
                {
                    Parameters =
                    {
                        { "@ID", SqlDbType.Int, 0, "ID" }
                    }
                };
                adapter.DeleteCommand.Parameters["@ID"].Direction = ParameterDirection.Output;

                var data_set = new DataSet();

                adapter.Fill(data_set);

                var table = data_set.Tables[0];

                var row = table.NewRow();
                row["Name"] = "Петров Пётр Петрович";
                row["Birthday"] = "21.04.2012";
                table.Rows.Add(row);

                //adapter.Update(data_set);

                var adapter2 = new SqlDataAdapter("SELECT * FROM People", connection);
                var builder = new SqlCommandBuilder(adapter2);
                adapter2.InsertCommand = builder.GetInsertCommand();
                adapter2.UpdateCommand = builder.GetUpdateCommand();
                adapter2.DeleteCommand = builder.GetDeleteCommand();
            }
        }
    }
}
