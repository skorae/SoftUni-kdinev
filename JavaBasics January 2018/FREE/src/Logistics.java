import java.util.Scanner;

public class Logistics {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int totalTons = 0;
        int totalPrice = 0;
        int price = 0;
        int microbus = 0;
        int truck = 0;
        int train = 0;

        for (int i = 1; i <= n; i++) {
            int ton = Integer.parseInt(scanner.nextLine());

            if (ton < 4) {
                price = ton * 200;
                microbus += ton;
            } else if (ton < 12) {
                price = ton * 175;
                truck += ton;
            } else {
                price = ton * 120;
                train += ton;
            }
            totalTons += ton;
            totalPrice += price;

        }
        double middlePrice = totalPrice * 1.0 / totalTons;
        double micro = microbus * 1.0 / totalTons * 100;
        double trUcking = truck * 1.0 / totalTons * 100;
        double traIning = train * 1.0 / totalTons * 100;

        System.out.printf("%.2f\n", middlePrice);
        System.out.printf("%.2f%%\n",micro);
        System.out.printf("%.2f%%\n",trUcking);
        System.out.printf("%.2f%%",traIning);
    }
}
