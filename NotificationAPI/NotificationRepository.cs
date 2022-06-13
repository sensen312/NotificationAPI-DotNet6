using NotificationAPI.Entities;
using System.Data;
using System.Data.SqlClient;

namespace NotificationAPI
{
    public class NotificationRepository : INotificationRepository
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection("Server=(local);Database=NotificationDatabase;Trusted_Connection=true;");
        }

        //public void CreateTable()
        //{
        //    var sql = "CREATE TABLE Notifications (" +
        //        "NotificationId UNIQUEIDENTIFIER NOT NULL, " +
        //        "RecievedDate DATETIME2, " +
        //        "SentDate DATETIME2, " +
        //        "DeviceId varchar(255) NOT NULL, " +
        //        "UserId varchar(255) NOT NULL, " +
        //        "ApplicationName varchar(255) NOT NULL, " +
        //        "CONSTRAINT PK_NotificationTracker PRIMARY KEY(NotificationId))	";
        //    using (var connection = GetConnection())
        //    using (var command = new SqlCommand(sql, connection))
        //    {
        //        command.CommandType = CommandType.Text;
        //        connection.Open();
        //        var rowsInserted = command.ExecuteNonQuery();
        //    }
        //}
       
        public async Task AddNotificationAsync(Notification notification)
        {
            // how do I fix the async?
            // where do I put the await 
            var sql = "INSERT INTO Notifications(NotificationId, SentDate, DeviceId, UserId, ApplicationName) VALUES (@NotificationId, @SentDate, @DeviceId, @UserId, @ApplicationName)";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@NotificationId", notification.NotificationId);
                command.Parameters.AddWithValue("@SentDate", notification.SentDate);
                command.Parameters.AddWithValue("@DeviceId", notification.DeviceId);
                command.Parameters.AddWithValue("@UserId", notification.UserId);
                command.Parameters.AddWithValue("@ApplicationName", notification.ApplicationName);

                connection.Open();
                var rowsInserted = command.ExecuteNonQuery();
            }
            
            // do I need to save to async?
        }
    

        public async Task<int> UpdateNotificationAsync(Notification notification)
        {
            var sql = "UPDATE Notifications SET RecievedDate = @RecievedDate WHERE NotificationId = (@NotificationId)";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@NotificationId", notification.NotificationId);
                command.Parameters.AddWithValue("@RecievedDate", notification.RecievedDate);
              
                connection.Open();
                var rowsInserted = command.ExecuteNonQuery();

                // makes sure that we know how many notifications were updated
                // I don't know if we should check if there is more than one notification updated 
                // since in theory that shouldn't be possible or should we even care?
                return rowsInserted;
                
            }
        }
       
        
    }
}
