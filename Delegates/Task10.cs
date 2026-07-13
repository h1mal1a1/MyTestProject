namespace MyTestProject.Delegates;

public class Task10
{
    public void ExecuteSafely(Action action, Action<Exception> errorHandler)
    {
        try
        {
            action.Invoke();
        }
        catch(Exception ex)
        {
            errorHandler.Invoke(ex);
        }
    }
}