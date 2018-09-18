namespace Tutkoo.mintyfusion.CenterPoint.StepsPanel.Tasks
{
    #region namespace
    using Model;
    using NPoco;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    #endregion namespace

    #region Class
    public class CommonDatabaseTasks<T> where T : EntityBase
    {
        #region Fields
        private readonly string connectionString = string.Empty;
        #endregion Fields

        #region Constructor
        public CommonDatabaseTasks(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString");

            this.connectionString = connectionString;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// To Fetch Record By requested ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Requested record if found</returns>
        public async Task<T> GetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");

            string loggingMessagePrefix = "CommonDatabaseTasks:GetAsync";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); /* Opens connection to the database */

                    using (IDatabase database = new Database(connection))
                    {
                        return await database.SingleByIdAsync<T>(id);
                    }
                }
            }
            catch (SqlException se)
            {
                throw new InvalidOperationException(string.Format("{0}:{1}", loggingMessagePrefix, se.Message));
            }
        }

        /// <summary>
        /// To Fetch All Records with passed id and query
        /// </summary>
        /// <returns> List of all Records with passed id and query</returns>
        public async Task<IList<T>> GetAsync()
        {
            string loggingMessagePrefix = "CommonDatabaseTasks:GetAllAsync with query and id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); /* Opens connection to the database */

                    using (IDatabase database = new Database(connection))
                    {
                        return await database.FetchAsync<T>();
                    }
                }
            }
            catch (SqlException se)
            {
                throw new InvalidOperationException(string.Format("{0}:{1}", loggingMessagePrefix, se.Message));
            }
        }
        #endregion Public Methods
    }
    #endregion Class
}