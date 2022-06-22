using NotificationAPI.Entities;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotificationAPI
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly string _connectionString;

        public NotificationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString); 
        }


    
        public async Task AddNotificationAsync(Notification notification)
        {
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
                var rowsInserted = await command.ExecuteNonQueryAsync();
            }
            
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
                var rowsInserted = await command.ExecuteNonQueryAsync();


                return rowsInserted;
                
            }
        }
    }
}
