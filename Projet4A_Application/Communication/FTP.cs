using CoreFtp;
using System;
using System.IO;

namespace Communication
{
    public class FTP
    {
        private string mobilePath = "file:///android_asset/Livres/";
        private string raspPath = "/home/pi/Documents/";

        private string rasp_Host = "192.168.0.14";

        /// <summary>
        /// Upload
        /// File with extension
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task upload_Async(string file)
        {
            using (var ftpClient = new CoreFtp.FtpClient(new FtpClientConfiguration
            {
                Host = rasp_Host,
                Username = "pi",
                Password = "pi"
            }))
            {
                //var fileinfo = new FileInfo("data/data/test.png");
                var fileinfo = new FileInfo(mobilePath + file);
                if (fileinfo.Exists)
                {
                    await ftpClient.LoginAsync();

                    //using (var writeStream = await ftpClient.OpenFileWriteStreamAsync("/home/pi/Documents/test3.png"))
                    using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(raspPath+file))
                    {
                        var fileReadStream = fileinfo.OpenRead();
                        await fileReadStream.CopyToAsync(writeStream);
                    }
                }
            }
        }


        /// <summary>
        /// Download
        /// File with extension
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task download_Async(string file)
        {
            using (var ftpClient = new CoreFtp.FtpClient(new FtpClientConfiguration
            {
                Host = rasp_Host,
                Username = "pi",
                Password = "pi"
            }))
            {
                var tempFile = new FileInfo(mobilePath + file);
                await ftpClient.LoginAsync();
                using (var ftpReadStream = await ftpClient.OpenFileReadStreamAsync(raspPath + file))
                {
                    using (var fileWriteStream = tempFile.OpenWrite())
                    {
                        await ftpReadStream.CopyToAsync(fileWriteStream);
                    }
                }
            }
        }
    }
}
