import java.util.Scanner;

public class CarToGo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();

        double price = 0;
        String type = "";
        String clas = "";

        if (budget <= 100) {
            clas = "Economy class";
            if (season.equalsIgnoreCase("summer")) {
                type = "Cabrio";
                price = budget * 0.35;
            } else if (season.equalsIgnoreCase("winter")) {
                type = "Jeep";
                price = budget * 0.65;
            }
        } else if (budget <= 500) {
            clas = "Compact class";
            if (season.equalsIgnoreCase("summer")) {
                type = "Cabrio";
                price = budget * 0.45;
            } else if (season.equalsIgnoreCase("winter")) {
                type = "Jeep";
                price = budget * 0.8;
            }
        } else {
            clas = "Luxury class";
            type = "Jeep";
            price = budget * 0.9;
        }
        System.out.printf("%s\n%s - %.2f\n",clas,type,price);
    }
}