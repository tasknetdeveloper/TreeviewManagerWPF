namespace Model
{
    public interface IActionMainController
    {
        void CreateNew(Node node);
        void Delete(Node node);
        void Rename(string newName, Node oldNode);
    }

    public interface ITreeviewManager
    {
        void Rename(string newName);
        void DeleteNode();
        void CreateNew(string Name, Node node);
    }

}
