import java.util.Scanner;

public class Vacation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int seniors = Integer.parseInt(scanner.nextLine());
        int young = Integer.parseInt(scanner.nextLine());
        int nights = Integer.parseInt(scanner.nextLine());
        String transport = scanner.nextLine();
        double travel = 0;

        double sleep = nights * 1.0 * 82.99;

        switch (transport) {
            case "train":
                if (seniors + young >= 50)
                    travel = 2 * (((seniors * 24.99) + (young * 14.99)) * 0.5);
                else
                    travel = 2 * (((seniors * 24.99) + (young * 14.99)));
                break;
            case "bus":
                travel = 2 * (seniors * 32.50 + young * 28.50);
                break;
            case "boat":
                travel = 2 * (seniors * 42.99 + young * 39.99);
                break;
            case "airplane":
                travel = 2 * (seniors * 70 + young * 50);
                break;
        }
        double total = (travel + sleep) + ((travel + sleep) * 0.1);

        System.out.printf("%.2f", total);
    }
}