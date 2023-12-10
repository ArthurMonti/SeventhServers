namespace SeventhServers.Domain.Utils
{
    public static class Base64Convert
    {

        public static string ToString(byte[] base64)
        {
            return base64.ToString();
        }

        public static byte[] ToBytes(string base64)
        {
            return Convert.FromBase64String(base64);
        }
    }
}
