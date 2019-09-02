import java.util.Scanner;

public class Vegetable_Market {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double vegetablePPK = Double.parseDouble(scanner.nextLine());
        double fruitPPK = Double.parseDouble(scanner.nextLine());
        int vegetableKilos = Integer.parseInt(scanner.nextLine());
        int fruitKilos = Integer.parseInt(scanner.nextLine());

        double profitInEUR = ((vegetablePPK * vegetableKilos) + (fruitKilos * fruitPPK)) / 1.94;

        System.out.printf("%.2f", profitInEUR);
    }
}
