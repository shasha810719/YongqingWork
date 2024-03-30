namespace YongqingWork.Modules.Setting
{
    public interface IDatabaseConnection
    {
        Task<string> GetConnString();
    }
}
