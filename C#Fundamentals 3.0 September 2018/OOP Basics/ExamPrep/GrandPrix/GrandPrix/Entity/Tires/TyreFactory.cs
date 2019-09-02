
public class TyreFactory
{
    public Tyre GetTyre(string[] arr)
    {
        string type = arr[0];
        double hardness = double.Parse(arr[1]);
        Tyre tyre;

        switch (type)
        {
            case "Ultrasoft ":
                double grip = double.Parse(arr[2]);
                tyre = new UltrasoftTyre(hardness, grip);
                break;
            case "Hard":
                tyre = new HardTyre(hardness);
                break;
            default:
                return null;
        }

        return tyre;
    }
}

