/* File : compteEEL.cs
 * Author : T.IS-E2A Jonathan Borel-Jaquet
 * Version : 1.0.0
 * Date : 01.10.2020
 * Description : compteEEL.cs file containing the two main classes of the application, MyFolder and MyFile
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BJ_epreuve_POO
{
    /// <summary>
    /// Class representing a folder on our hard drive
    /// </summary>
    class MyFolder
    {
        private List<MyFile> lstFiles;
        private int nbrFiles;
        private long totalSize;

        public List<MyFile> LstFiles { get => lstFiles; private set => lstFiles = value; }
        public int NbrFiles { get => nbrFiles; private set => nbrFiles = value; }
        public long TotalSize { get => totalSize; private set => totalSize = value; }

        public MyFolder()
        {
            lstFiles = new List<MyFile>();
            OpenFolder();
        }
        public MyFolder(List<MyFile> lstFiles)
        {
            this.lstFiles = lstFiles;
        }


        /// <summary>
        /// Open a folder browser dialog to read a specify folder in our hard drive
        /// </summary>
        private void OpenFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    TotalSize = 0;
                    DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);
                    FileInfo[] files = di.GetFiles();
                    this.NbrFiles = files.Length;
                    foreach (FileInfo file in files)
                    {
                        MyFile myfile = new MyFile(file.FullName,file.Name, file.CreationTime, file.LastWriteTime, file.Length, file.Extension);
                        this.TotalSize += file.Length;
                        lstFiles.Add(myfile);
                    }
                }
            }
        }
        /// <summary>
        /// Create a new folder with filtered items
        /// </summary>
        /// <param name="ext">Extension to filter</param>
        /// <param name="maxSize">Maximum file size (octet)</param>
        /// <returns>Returns a new instance of myFolder with the files filtered</returns>
        public MyFolder FilterFolder(string ext, long maxSize)
        {
            List<MyFile> result = new List<MyFile>();
            foreach (MyFile file in lstFiles)
            {
                if (file.Extension.Substring(1) == ext && file.Size <maxSize)
                {
                    result.Add(file);
                }
            }
            return new MyFolder(result);
        }
    }
    /// <summary>
    /// Class representing a file on our hard drive
    /// </summary>
    class MyFile 
    {
        private string path;
        protected string filename;
        private DateTime datecreation;
        private DateTime datemodification;
        private long size;
        private string extension;

        public string Extension { get => extension; private set => extension = value; }
        public long Size { get => size; private set => size = value; }

        public MyFile(string path,string filename, DateTime datecreation, DateTime datemodification, long size, string extension)
        {
            this.path = path;
            this.filename = filename;
            this.datecreation = datecreation;
            this.datemodification = datemodification;
            this.Size = size;
            this.Extension = extension;
        }

        /// <summary>
        /// Calculate the checksum of a file in (sha256) format
        /// </summary>
        /// <returns>the checksum in SHA256</returns>
        public string GetSHA256Checksum()
        {
            using (FileStream stream = File.OpenRead(path))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }


    }
}
