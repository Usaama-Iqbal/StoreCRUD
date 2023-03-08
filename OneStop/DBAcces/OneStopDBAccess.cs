using DataAccess.Models;
using DataAccess.Services;
using System.Data;
using System.Data.SqlClient;

namespace DBAcces
{
    public class OneStopDBAccess
    {

       // SqlConnection Con = new SqlConnection(@"Data Source = DESKTOP - UQL7P1I\SQLEXPRESS; Initial Catalog = Onestop; Integrated Security = True");
        public OneStopDBAccess()
        {

        }

        public int SaveStoreRecord(StoreEntity storeEntity)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.connectionString))
            {
                int result = 0;
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Execute spInsertRecord @Name,@Category,@Quantity,@Weight,@Price,@Date";

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = storeEntity.Name;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = storeEntity.Category;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int, 0).Value = storeEntity.Quantity;
                cmd.Parameters.Add("@Weight", SqlDbType.NVarChar, 50).Value = storeEntity.Weight;
                cmd.Parameters.Add("@Price", SqlDbType.Int, 0).Value = storeEntity.Price;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 50).Value = storeEntity.Date;


                connection.Open();

                result = cmd.ExecuteNonQuery();
                connection.Close();

                return result;


            }
        }


            public int UpdateStoreRecord(StoreEntity entity)
            {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.connectionString))
            {
                int result = 0;
                // Create a new SqlCommand object with the stored procedure name and SqlConnection object
                SqlCommand cmd = new SqlCommand("spUpdateRecord", connection);

                // Set the CommandType property of the SqlCommand object to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                // Create a new SqlDataAdapter object with the SqlCommand object
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Define the parameters for the stored procedure
                cmd.Parameters.Add("@id", SqlDbType.Int, 0).Value = entity.id;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = entity.Name;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = entity.Category;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int, 0).Value = entity.Quantity;
                cmd.Parameters.Add("@Weight", SqlDbType.NVarChar, 50).Value = entity.Weight;
                cmd.Parameters.Add("@Price", SqlDbType.Int, 0).Value = entity.Price;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 50).Value = entity.Date;

                connection.Open();

                result = cmd.ExecuteNonQuery();
                connection.Close();

                return result;

            }
            }

        public int DeleteStoreRecord(int StoreId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.connectionString))
            {
                int result = 0;

                // Create a new SqlCommand object for the stored procedure
                SqlCommand cmd = new SqlCommand("spDeleteRecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add the parameters for the stored procedure
                cmd.Parameters.AddWithValue("@id", StoreId);


                connection.Open();

                result = cmd.ExecuteNonQuery();
                connection.Close();

                return result;

                // Execute the command

            }
        }

        public DataTable GetRecord()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.connectionString))
            {
                // Create a new SqlCommand object with the stored procedure name and SqlConnection object
                SqlCommand cmd = new SqlCommand("spShowRecord", connection);

                // Set the CommandType property of the SqlCommand object to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                // Create a new SqlDataAdapter object with the SqlCommand object
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Create a new DataTable object to hold the data returned by the stored procedure
                DataTable dataTable = new DataTable();

                // Call the Fill method of the SqlDataAdapter object, passing in the DataTable object as the argument
                adapter.Fill(dataTable);

                // Return the DataTable object
                return dataTable;
            }
        }

    }
}