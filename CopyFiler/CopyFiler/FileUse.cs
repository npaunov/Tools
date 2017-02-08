using System.IO;

namespace CopyFiler
{
    public class FileUse
    {
        public static void Copy(string sourcePath, string targetPath)
        {
            if (System.IO.Directory.Exists(sourcePath))
            {
                System.IO.Directory.CreateDirectory(targetPath);

                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = System.IO.Path.GetFileName(s);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }

                CopyDir(sourcePath, targetPath);
                return;
            }

            System.IO.File.Copy(sourcePath, targetPath, true);


        }

        private static void CopyDir(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));

            foreach (var directory in Directory.GetDirectories(sourceDir))
                CopyDir(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
        }
    }
}
