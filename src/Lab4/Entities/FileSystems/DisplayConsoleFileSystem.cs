using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
public class DisplayConsoleFileSystem : IDisplayFileSystem
{
    public void ShowTreeGoto(string path)
    {
        if (Directory.Exists(path))
        {
            ShowTreeList(path);
        }
        else
        {
            Console.WriteLine($"The path does not exist: {path}");
        }
    }

    public void Delete(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Console.WriteLine($"The file does not exist at this address: {path}");
        }
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        if (File.Exists(sourcePath))
        {
            string fileName = Path.GetFileName(sourcePath);
            string newDestinationPath = Path.Combine(destinationPath, fileName);

            if (Directory.Exists(destinationPath))
            {
                File.Copy(sourcePath, newDestinationPath);
            }
            else
            {
                Console.WriteLine($"The directory doen't exist: {destinationPath}");
            }
        }
        else
        {
            Console.WriteLine($"The file does not exist at this address: {sourcePath}");
        }
    }

    public void Rename(string path, string name)
    {
        if (File.Exists(path))
        {
            string? directoryName = Path.GetDirectoryName(path);

            if (directoryName != null)
            {
                string fullPath = Path.Combine(directoryName, name);
                File.Move(path, fullPath);
            }

            Console.WriteLine($"The file was successfully renamed");
        }
        else
        {
            Console.WriteLine($"The file does not exist at this address: {path}");
        }
    }

    public void Move(string sourcePath, string destinationPath)
    {
        if (File.Exists(sourcePath))
        {
            string pathOld = Path.GetFileName(sourcePath);
            string destinationFullPath = Path.Combine(destinationPath, pathOld);

            File.Move(sourcePath, destinationFullPath);

            Console.WriteLine($"The file was successfully moved");
        }
        else
        {
            Console.WriteLine($"The file does not exist at this address: {sourcePath}");
        }
    }

    public void Show(string path, string mode)
    {
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);

            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine($"The file does not exist at this address: {path}");
        }
    }

    public void ShowTreeList(string directoryPath, int depth = 1, string fileSymbol = "-", string folderSymbol = "+", string indent = "    ")
    {
        ShowTreeList(directoryPath, depth, 0, fileSymbol, folderSymbol, indent);
    }

    private static void ShowTreeList(string path, int maxDepth, int depth, string fileSymbol, string folderSymbol, string indent)
    {
        if (Directory.Exists(path))
        {
            string outPut = new string(' ', depth * indent.Length);

            Console.WriteLine($"{outPut}{folderSymbol} {Path.GetFileName(path)}");

            foreach (string file in Directory.GetFiles(path))
            {
                Console.WriteLine($"{new string(' ', (depth + 1) * indent.Length)}{fileSymbol} {Path.GetFileName(file)}");
            }

            if (depth < maxDepth)
            {
                foreach (string subdirectory in Directory.GetDirectories(path))
                {
                    ShowTreeList(subdirectory, maxDepth, depth + 1, fileSymbol, folderSymbol, indent);
                }
            }
        }
        else
        {
            Console.WriteLine($"The folder does not exist at this address: {path}");
        }
    }
}
