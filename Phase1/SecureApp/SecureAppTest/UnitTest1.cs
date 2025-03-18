using SecureApp;

namespace SecureAppTest
{
    [TestFixture]
    public class SecurityTests
    {
        [Test]
        public void Test_UserRegistrationAndAuthentication()
        {
            UserManager userManager = new UserManager();
            bool isRegistered = userManager.Register("TestUser", "TestPassword");
            Assert.IsTrue(isRegistered);
            Assert.IsTrue(userManager.Authenticate("TestUser", "TestPassword"));
            Assert.IsFalse(userManager.Authenticate("TestUser", "WrongPassword"));
        }

        [Test]
        public void Test_DataEncryption()
        {
            string originalData = "SecretInfo";
            string encryptedData = EncryptionHelper.Encrypt(originalData);
            string decryptedData = EncryptionHelper.Decrypt(encryptedData);
            Assert.AreEqual(originalData, decryptedData);
        }
    }
}