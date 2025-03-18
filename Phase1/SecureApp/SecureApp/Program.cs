using System;
using System.Security.Cryptography;
using System.Text;
using NLog;

namespace SecureApp
{
    /// <summary>
    /// Represents a user in the system with authentication features.
    /// </summary>
    public class User
    {
        public string Username { get; set; }
        public string HashedPassword { get; private set; }

        public User(string username, string password)
        {
            Username = username;
            HashedPassword = HashPassword(password);
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public bool Authenticate(string password)
        {
            return HashedPassword == HashPassword(password);
        }
    }

    /// <summary>
    /// Manages user registration and authentication.
    /// </summary>
    public class UserManager
    {
        private readonly Dictionary<string, User> users = new Dictionary<string, User>();

        public bool Register(string username, string password)
        {
            if (users.ContainsKey(username))
                return false; // User already exists

            users[username] = new User(username, password);
            return true;
        }

        public bool Authenticate(string username, string password)
        {
            if (users.ContainsKey(username))
            {
                return users[username].Authenticate(password);
            }
            return false;
        }
    }

    /// <summary>
    /// Provides encryption and decryption utilities.
    /// </summary>
    public static class EncryptionHelper
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");

        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] encrypted = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(plainText), 0, plainText.Length);
                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Decrypt(string encryptedText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] decrypted = decryptor.TransformFinalBlock(Convert.FromBase64String(encryptedText), 0, Convert.FromBase64String(encryptedText).Length);
                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }

    /// <summary>
    /// Handles logging and error management.
    /// </summary>
    public static class LoggerHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void LogInfo(string message) => Logger.Info(message);
        public static void LogError(Exception ex) => Logger.Error(ex);
    }

    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    class Program
    {
        static void Main()
        {
            try
            {
                LoggerHelper.LogInfo("Application Started");

                UserManager userManager = new UserManager();

                // User Registration
                bool isRegistered = userManager.Register("Alice", "SecurePass123");
                Console.WriteLine(isRegistered ? "User registered successfully." : "User already exists.");

                // User Authentication
                bool isAuthenticated = userManager.Authenticate("Alice", "SecurePass123");
                Console.WriteLine(isAuthenticated ? "Authentication successful" : "Authentication failed");

                // Data Encryption
                string encryptedData = EncryptionHelper.Encrypt("Sensitive Data");
                Console.WriteLine($"Encrypted Data: {encryptedData}");

                string decryptedData = EncryptionHelper.Decrypt(encryptedData);
                Console.WriteLine($"Decrypted Data: {decryptedData}");
            }
            catch (Exception ex)
            {
                LoggerHelper.LogError(ex);
                Console.WriteLine("An error occurred. Check logs for details.");
            }
        }
    }
}
