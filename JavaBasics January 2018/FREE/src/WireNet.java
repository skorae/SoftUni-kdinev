import java.util.Scanner;

public class WireNet {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int a = Integer.parseInt(scanner.nextLine());
        int b = Integer.parseInt(scanner.nextLine());
        double heightNet = Double.parseDouble(scanner.nextLine());
        double pricePerMeter = Double.parseDouble(scanner.nextLine());
        double oneM2inKilos = Double.parseDouble(scanner.nextLine());

        double lentght = 2 * a + 2 * b;
        double cost = lentght * pricePerMeter;
        double weight = (lentght * heightNet) * oneM2inKilos;

        System.out.printf("%.0f\n%.2f\n%.3f", lentght, cost, weight);


    }
}
