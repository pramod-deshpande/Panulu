namespace Panulu.Entities; 
public class TaskItem {

    public int Id { get; set; }
    public string Title { get; set; }
    public string? Note { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? TaskDateTime { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime CompletionDateTime { get; set; }




}
