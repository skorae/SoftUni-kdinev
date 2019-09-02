import java.util.Scanner;

public class ToyShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double excursion = Double.parseDouble(scanner.nextLine());
        double puzzle = Double.parseDouble(scanner.nextLine());
        double dolls = Double.parseDouble(scanner.nextLine());
        double bear = Double.parseDouble(scanner.nextLine());
        double minion = Double.parseDouble(scanner.nextLine());
        double truck = Double.parseDouble(scanner.nextLine());
        double total = 0;
        double diff = 0;


        double count = puzzle + dolls + bear + minion + truck;
        double profit = (puzzle * 2.60) + (dolls * 3.0) + (bear * 4.10) + (minion * 8.20) + (truck * 2.0);

        if (count >= 50) {
            total = profit * 0.75 * (0.90);
        } else {
            total = profit * 0.90;
        }
        if (excursion <= total) {
            diff = total - excursion;
            System.out.printf("Yes! %.2f lv left.", diff);
        } else {
            diff = excursion - total;
            System.out.printf("Not enough money! %.2f lv needed.", diff);
        }
    }
}
