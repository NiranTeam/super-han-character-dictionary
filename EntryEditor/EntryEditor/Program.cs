using MongoDB.Driver;

namespace EntryEditor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            string connectionString = "";

            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("SuperHanCharacterDictionary");

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(database));
        }
    }
}