import java.util.Scanner;

public class Harvest {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int X = Integer.parseInt(scanner.nextLine());
        double Y = Double.parseDouble(scanner.nextLine());
        int Z = Integer.parseInt(scanner.nextLine());
        int workers = Integer.parseInt(scanner.nextLine());

        double totalGrapes = X * Y;
        double wine = 0.4 * totalGrapes / 2.5;
        double result = 0;

        if (wine < Z) {
            result = Math.floor(Z - wine);
            System.out.printf("It will be a tough winter! More %.0f liters wine needed.", result);
        } else {
            result = Math.ceil(wine - Z);
            double forWorkers = Math.ceil(result / workers);
            System.out.printf("Good harvest this year! Total wine: %.0f liters.%n%.0f liters left -> %.0f liters per person.", Math.floor(wine), result, forWorkers);
        }
    }
}
