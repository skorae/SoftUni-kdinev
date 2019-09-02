import java.util.Scanner;

public class P15 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();

        if (season.equals("winter")) {
            if (budget <= 100) {
                double newBudget = budget * 0.70;
                System.out.printf("Somewhere in Bulgaria%nHotel - %.2f", newBudget);
            } else if (budget <= 1000) {
                double newBudget = budget * 0.80;
                System.out.printf("Somewhere in Balkans%nHotel - %.2f", newBudget);
            } else {
                double newBudget = budget * 0.90;
                System.out.printf("Somewhere in Europe%nHotel - %.2f", newBudget);
            }
        } else if (season.equals("summer")) {
            if (budget <= 100) {
                double newBudget = budget * 0.30;
                System.out.printf("Somewhere in Bulgaria%nCamp - %.2f", newBudget);
            } else if (budget <= 1000) {
                double newBudget = budget * 0.40;
                System.out.printf("Somewhere in Balkans%nCamp - %.2f", newBudget);
            } else {
                double newBudget = budget * 0.90;
                System.out.printf("Somewhere in Europe%nHotel - %.2f", newBudget);
            }
        }
    }
}
