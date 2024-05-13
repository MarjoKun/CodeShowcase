namespace UI.Screens
{
    public interface IScreen<in T> where T : class
    {
        void InitializeManager(T manager);
    }
}