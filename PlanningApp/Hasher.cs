using System.Security.Cryptography;
using System.Text;

namespace PlanningApp
{
    public class Hasher
    {
        public string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedData = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                foreach (var byteBlock in hashedData)
                {
                    builder.Append(byteBlock.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}