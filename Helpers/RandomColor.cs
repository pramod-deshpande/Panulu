namespace Panulu.Helpers;
public static class RandomColor {
    private static readonly List<string> colors = new() { "#FFF3E0", "#FFF8E1", "#FFFDE7", "#E8F5E9", "#F1F8E9", "#F9FBE7", "#E0F2F1", "#E0F7FA", "#E1F5FE"
                                            ,"#EDE7F6","#E8EAF6","#E3F2FD","#F3E5F5","#FCE4EC","#FFEBEE","#FBE9E7"};

    public static string GetRandomColor() {
        Random rnd = new();
        var val = rnd.Next(colors.Count);
        return colors[val];
    }
}

