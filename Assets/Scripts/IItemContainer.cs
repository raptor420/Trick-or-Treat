
public interface IItemContainer {

    bool ContainsItem(Items item);
    bool RemoveItem(Items item);
    bool Additem(Items item);
    bool IsFull();
    int itemcount(Items item);
}
