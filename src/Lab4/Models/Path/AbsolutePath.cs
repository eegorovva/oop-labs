namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Path;
public static class AbsolutePath
{
    public static bool GetTypeOfPath(string path)
    {
        if (System.IO.Path.IsPathRooted(path) != true)
        {
            return false;
        }

        return true;
    }
}
