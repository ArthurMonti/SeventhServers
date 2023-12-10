namespace SeventhServers.Domain.Abstractions.FileManagement
{
    public interface IVideoFileManagement
    {
        Task SaveBase64(byte[] file, string nameFile);
        Task<byte[]> GetBase64(string nameFile);

        void DeleteFile(string nameFile);
    }
}
