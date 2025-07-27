using System;

// Task.cs
public class Task
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public string Status { get; set; }
    public Task Next { get; set; }

    public Task(int taskId, string taskName, string status)
    {
        TaskId = taskId;
        TaskName = taskName ?? throw new ArgumentNullException(nameof(taskName));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        Next = null;
    }

    public override string ToString()
    {
        return $"Task{{TaskId={TaskId}, TaskName={TaskName}, Status={Status}}}";
    }
}

// TaskManagement.cs
public class TaskManagement
{
    private Task _head;

    public TaskManagement()
    {
        _head = null;
    }

    public void AddTask(Task task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        task.Next = _head;
        _head = task;
    }

    public Task SearchTask(int taskId)
    {
        Task current = _head;
        while (current != null)
        {
            if (current.TaskId == taskId)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public void TraverseTasks()
    {
        Task current = _head;
        while (current != null)
        {
            Console.WriteLine(current);
            current = current.Next;
        }
    }

    public void DeleteTask(int taskId)
    {
        Task current = _head;
        Task prev = null;

        if (current != null && current.TaskId == taskId)
        {
            _head = current.Next;
            return;
        }

        while (current != null && current.TaskId != taskId)
        {
            prev = current;
            current = current.Next;
        }

        if (current == null)
            return;

        prev.Next = current.Next;
    }
}

/*
COMPLEXITY:
Add Operation: O(1)
Search Operation: O(n)
Traverse Operation: O(n)
Delete Operation: O(n)
Linked lists provide efficient insertions and deletions but have linear time complexity for search and traversal.
*/
