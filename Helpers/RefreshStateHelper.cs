namespace Panulu.Helpers; 
public static class RefreshStateHelper {

    public static event Action RefreshRequested;

    public static void CallRequestRefresh() {
        RefreshRequested?.Invoke();
    }
}
