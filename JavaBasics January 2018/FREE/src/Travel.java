import java.util.Scanner;

public class Travel {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();
        String sleep = "";
        String location = "";
        double newbudget = 0;

        if (season.equalsIgnoreCase("summer") && budget <= 1000) {
            sleep = "Camp";
            if (budget <= 100) {
                newbudget = budget * 0.30;
                location = "Bulgaria";
            } else if (budget <= 1000) {
                newbudget = budget * 0.40;
                location = "Balkans";
            }
        } else if (season.equalsIgnoreCase("winter") && budget <= 1000) {
            sleep = "Hotel";
            if (budget <= 100) {
                newbudget = budget * 0.70;
                location = "Bulgaria";
            } else if (budget <= 1000) {
                newbudget = budget * 0.80;
                location = "Balkans";
            }
        } else {
            sleep = "Hotel";
            newbudget = budget * 0.90;
            location = "Europe";
        }
        System.out.printf("Somewhere in %s%n%s - %.2f",location,sleep,newbudget);
    }
}




