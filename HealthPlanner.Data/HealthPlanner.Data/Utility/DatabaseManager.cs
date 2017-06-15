using MongoDB.Driver;
using System.Security.Authentication;

namespace HealthPlanner.Data.Utility
{
    internal class DatabaseManager
    {
        // TODO:  skal der håndteres instanser af nogle af disse objekter? bliver der oprettet for mange forbindelser eller objekter?

        internal static IMongoDatabase CreateConnection(string connectionString)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            return client.GetDatabase("healthplanner");
        }
    }
}
