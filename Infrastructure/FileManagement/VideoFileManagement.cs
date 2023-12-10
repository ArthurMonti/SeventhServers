using SeventhServers.Domain.Abstractions.FileManagement;

namespace SeventhServers.Infrastructure.FileManagement
{
    public class VideoFileManagement : IVideoFileManagement
    {
        private readonly string Path = AppContext.BaseDirectory + "\\VIDEOS";

        public VideoFileManagement() 
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            
        }

        public async Task SaveBase64(byte[] file, string nameFile)
        {
            await File.WriteAllBytesAsync(Path + $"\\{nameFile}", file);           
        }

        public async Task<byte[]> GetBase64(string nameFile)
        {
            var bytes = await File.ReadAllBytesAsync(Path + $"\\{nameFile}");

            return bytes;
        }

        public void DeleteFile(string nameFile)
        {
            File.Delete(Path + $"\\{nameFile}");
        }
    }
}
