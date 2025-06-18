class Task {
    int taskId;
    String taskName;
    String status;
    Task next;

    public Task(int taskId, String taskName, String status) {
        this.taskId = taskId;
        this.taskName = taskName;
        this.status = status;
        this.next = null;
    }
}

class TaskManagement {
    private Task head;

    public TaskManagement() {
        head = null;
    }

    public void addTask(Task task) {
        task.next = head;
        head = task;
    }

    public Task searchTask(int taskId) {
        Task current = head;
        while (current != null) {
            if (current.taskId == taskId) {
                return current;
            }
            current = current.next;
        }
        return null;
    }

    public void traverseTasks() {
        Task current = head;
        while (current != null) {
            System.out.println(current);
            current = current.next;
        }
    }

    public void deleteTask(int taskId) {
        Task current = head;
        Task prev = null;
        if (current != null && current.taskId == taskId) {
            head = current.next;
            return;
        }
        while (current != null && current.taskId != taskId) {
            prev = current;
            current = current.next;
        }
        if (current == null) return;
        prev.next = current.next;
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