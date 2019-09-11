using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        ArrayList<int> arr = new ArrayList<int>();
        arr.Add(5);
        arr[0] = arr[0] + 1;
        int element = arr.RemoveAt(0);
    }
}
