using Android.Content.Res;
using CoreFtp;
using System;
using System.IO;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;

namespace Communication
{
    public static class ftpPaths
    {
        public static String pathMobile = System.IO.Path.Combine((string)Android.OS.Environment.ExternalStorageDirectory, Android.OS.Environment.DirectoryDownloads) + "/";
    }


    public class FTP
    {
        //private string mobilePath =  "file:///android_asset/Livres/";  /data/user/0/com.companyname/files
        // private string mobilePath = "data/data/";

        String str = "storage/emulated/0/Download/"; //Android.OS.Environment.ExternalStorageDirectory

        //private string mobilePath = "storage/emulated/0/Download/"; //MARCHE BIEN

        //  Xamarin.Essentials.FileSystem.AppDataDirectory+"/";
        // Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)+"/";
        // "/data/user/0/com.companyname/files/"; 
        //Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDocuments).AbsolutePath  // chemin extern public



         //String str = System.IO.Path.Combine((string)Android.OS.Environment.ExternalStorageDirectory, Android.OS.Environment.DirectoryDocuments);


        private String mobilePath = System.IO.Path.Combine((string)Android.OS.Environment.ExternalStorageDirectory, Android.OS.Environment.DirectoryDownloads) +"/";



        //private String mobilePath = Android.Content.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);


        private string raspPath = "/home/pi/Desktop/Projet4A_livresPDF/" /*+ "Au_Soleil_Maupassant.pdf"*/;

        // private string rasp_Host = "192.168.0.14";
        private string rasp_Host = "10.3.141.1";

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


        public void download(string file)
        {
            // create an FTP client
            FluentFTP.FtpClient client = new FluentFTP.FtpClient("10.3.141.1");

            client.Credentials = new NetworkCredential("pi", "pi");
            client.Connect();

            if (client.FileExists(raspPath + file))
            {
                Console.WriteLine("\n\n========================== YEEEPPPP========== "+ raspPath + file );
                Console.WriteLine("\n\n========================== YEEEPPPP========== " + mobilePath + file);

                client.DownloadFile(mobilePath + file, raspPath + file);
            }
            else
            {
                Console.WriteLine("\n\n========================== NOOOPPP========== " + raspPath + file);
            }

            

            if (client.FileExists(mobilePath + file))
            {
                Console.WriteLine("\n\n========================== YEEEPPPP========== " + mobilePath + file);
            }
            else
            {
                Console.WriteLine("\n\n========================== NOOOPPP========== " + mobilePath + file);
            }



            client.Disconnect();
            Console.WriteLine("\n\n=======FINISHED===========\n\n");
        }


        public void dowload2(string file)
        {
            /*
            string FtpUrl = "192.168.0.14";
            string fileName = file;
            string userName = "pi";
            string password = "pi";
            string DownloadDirectory = this.raspPath;*/

            string inputfilepath = this.mobilePath + file;
            string ftphost = "10.3.141.1";
            string ftpfilepath = this.raspPath + file; 

            string ftpfullpath = "ftp://" + ftphost +"/"+ ftpfilepath;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("pi", "pi");
                byte[] fileData = request.DownloadData(ftpfullpath);

               
                using (FileStream fil = File.Create(inputfilepath))
                {

                   
                    fil.Write(fileData, 0, fileData.Length);
                    fil.Close();
                }
                

            }

            //test if file exists
            if (File.Exists(mobilePath + file))
            {
                Console.WriteLine("\n\n========================== YEEEPPPP========== " + mobilePath + file);
            }



        }

        public String getWritableAssetPath()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string webPath = Path.Combine(docPath, "Livres");

            return webPath;
        }

        public string getFilePath(string tab, string slug)
        {
            var root = this.getWritableAssetPath();
            var path = Path.Combine(root, "local-content", tab, slug + ".pdf");

            if (File.Exists(path))
            {
                var filePath = path;
                return filePath;
            }

            return "no file: " + path;
        }
    }
}
