namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
public class LocalFileSystem : IFileSystem
{
    private IDisplayFileSystem _displayFileSystem;

    public LocalFileSystem(IDisplayFileSystem displayFileSystem)
    {
        _displayFileSystem = displayFileSystem;
    }

    public void ShowTreeGoto(string path)
    {
        _displayFileSystem.ShowTreeGoto(path);
    }

    public void Delete(string path)
    {
        _displayFileSystem.Delete(path);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        _displayFileSystem.CopyFile(sourcePath, destinationPath);
    }

    public void Rename(string path, string name)
    {
        _displayFileSystem.Rename(path, name);
    }

    public void Move(string sourcePath, string destinationPath)
    {
        _displayFileSystem.Move(sourcePath, destinationPath);
    }

    public void Show(string path, string mode)
    {
        _displayFileSystem.Show(path, mode);
    }

    public void ShowTreeList(string directoryPath, int depth = 1, string fileSymbol = "-", string folderSymbol = "+", string indent = "    ")
    {
        _displayFileSystem.ShowTreeList(directoryPath, depth, fileSymbol, folderSymbol, indent);
    }
}
