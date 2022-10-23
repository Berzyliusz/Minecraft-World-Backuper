using System;
using System.IO;

namespace FileBackuperWF
{
    public static class Saver
    {
        public static void RestoreBackup(string worldToRestoreName)
        {
            string pathToBackupWorld = Path.Combine(Data.BACKUP_PATH, worldToRestoreName);
            string pathToWorld = Path.Combine(Data.WORLD_PATH, worldToRestoreName);

            CopyWorld(pathToBackupWorld, pathToWorld);
        }

        public static void SaveBackup(string worldToSaveName)
        {
            string pathToBackupWorld = Path.Combine(Data.BACKUP_PATH, worldToSaveName);
            string pathToWorld = Path.Combine(Data.WORLD_PATH, worldToSaveName);

            CopyWorld(pathToWorld, pathToBackupWorld);
        }

        private static void CopyWorld(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine($"World has not been found at path {sourcePath}");
                return;
            }

            TryDeletePath(destinationPath);
            EnsureFolderExists(destinationPath);

            CopyAllFiles(sourcePath, destinationPath);

            Console.WriteLine($"World copied");
        }

        static void CopyAllFiles(string sourcePath, string targetPath)
        {
            var di = new DirectoryInfo(sourcePath);
            var dirArr = di.GetDirectories();
            var files = di.GetFiles();

            foreach (var file in files)
            {
                var destinationFile = Path.Combine(targetPath, file.Name);
                File.Copy(file.FullName, destinationFile);
            }

            foreach (var directory in dirArr)
            {
                var targetDirectory = Path.Combine(targetPath, directory.Name);
                Directory.CreateDirectory(targetDirectory);
                CopyAllFiles(directory.FullName, targetDirectory);
            }
        }

        static void EnsureFolderExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        static void TryDeletePath(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }
    }
}
