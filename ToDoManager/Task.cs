class Task
{
    private int id;
    private string title;
    private bool isCompleted;

    public Task (int taskId, string taskTitle)
    {
        id = taskId;
        title = taskTitle;
        isCompleted = false;
    }
    public int Id
    {
        get { return id; }
    }
    public string Title
    {
        get { return title; }
    }

    public bool IsCompleted
    {
        get { return isCompleted; }
    }

    public void markCompleted()
    {
        isCompleted = true;
    }




}