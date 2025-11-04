namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
public interface IDisplayFileSystem
{
    public void ShowTreeGoto(string path);
    public void ShowTreeList(string directoryPath, int depth = 1, string fileSymbol = "-", string folderSymbol = "+", string indent = "   ");
    public void CopyFile(string sourcePath, string destinationPath);
    public void Delete(string path);
    public void Rename(string path, string name);
    public void Move(string sourcePath, string destinationPath);
    public void Show(string path, string mode);
}
