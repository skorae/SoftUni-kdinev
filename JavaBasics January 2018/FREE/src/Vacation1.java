import java.util.Scanner;

public class Vacation1 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();
        String sleep = "";
        String location = "";
        double price = 0;

        if (budget <= 1000) {
            sleep = "Camp";
            if (season.equalsIgnoreCase("summer")) {
                location = "Alaska";
                price = budget * 0.65;
            } else {
                location = "Morocco";
                price = budget * 0.45;
            }
        } else if (budget <= 3000) {
            sleep = "Hut";
            if (season.equalsIgnoreCase("summer")) {
                location = "Alaska";
                price = budget * 0.8;
            } else {
                location = "Morocco";
                price = budget * 0.6;
            }
        } else {
            sleep = "Hotel";
            price = budget * 0.9;
            if (season.equalsIgnoreCase("summer")) {
                location = "Alaska";
            } else {
                location = "Morocco";
            }
        }
        System.out.printf("%s - %s - %.2f", location, sleep, price);
    }
}
