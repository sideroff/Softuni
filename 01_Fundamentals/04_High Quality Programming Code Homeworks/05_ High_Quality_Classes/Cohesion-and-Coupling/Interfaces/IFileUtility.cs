namespace CohesionAndCoupling.Interfaces
{
    public interface IFileUtility
    {

        string GetFileExtension(string fileName);

        string GetFileNameWithoutExtension(string fileName);
    }
}