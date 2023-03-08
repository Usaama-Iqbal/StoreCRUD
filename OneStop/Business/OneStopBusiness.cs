using DataAccess.Models;
using DBAcces;
using System.Data;

namespace Business
{
    public class OneStopBusiness
    {
        public OneStopBusiness()
        {

        }


        StoreEntity obj = new StoreEntity();
        public int SaveStoreRecord(StoreEntity storeEntity)
        {
            OneStopDBAccess obj = new OneStopDBAccess();
            return obj.SaveStoreRecord(storeEntity);

        }

        public DataTable GetRecord()
        {
            // Create a new instance of the data access layer class
            OneStopDBAccess dal = new OneStopDBAccess();

            // Call the GetStudents method to get the student records
            DataTable recordTable = dal.GetRecord();

            // Return the DataTable object containing the student records
            return recordTable;
        }

        public int UpdateStoreRecord(StoreEntity entity)
        {
            OneStopDBAccess obj = new OneStopDBAccess();
            return obj.UpdateStoreRecord(entity);

        }

        public int DeleteStoreRecord(int StoreId)
        {
            // Create a new instance of the data access layer class
            OneStopDBAccess dal = new OneStopDBAccess();

            // Open a new database connection


            // Call the DeleteStudent method in the data access layer to delete the student record
            return dal.DeleteStoreRecord(StoreId);

            // Close the database connection

        }

    }
}