import java.util.Scanner;

public class SmartLilly {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int age = Integer.parseInt(scanner.nextLine());
        double washPrice = Double.parseDouble(scanner.nextLine());
        int toyPrice = Integer.parseInt(scanner.nextLine());

        double moneyGift = 0;
        double toys = 0;
        double firstGift = 0;

        for (int i = 1; i <= age; i++) {

            if (i % 2 == 0) {
                firstGift += 10;
                moneyGift += firstGift - 1;
            } else if (i % 2 == 1) {
                toys = toys + toyPrice;
            }
        }

        if (washPrice <= (moneyGift + toys)) {
            System.out.printf("Yes! %.2f", (moneyGift + toys) - washPrice);
        } else {
            System.out.printf("No! %.2f", washPrice - (moneyGift + toys));
        }
    }
}