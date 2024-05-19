public interface ICompletable
{
    void MarkComplete();
    bool IsCompleted { get; }
}