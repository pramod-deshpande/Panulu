namespace Panulu.Helpers;
public class RefreshStateHelper {

    public event Action RefreshRequested;

    public void CallRequestRefresh() {
        RefreshRequested?.Invoke();
    }
}
