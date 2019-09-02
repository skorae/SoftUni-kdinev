import java.util.Scanner;

public class Flowers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int hrizantemi = Integer.parseInt(scanner.nextLine());
        int rozi = Integer.parseInt(scanner.nextLine());
        int laleta = Integer.parseInt(scanner.nextLine());
        String season = scanner.nextLine();
        String holiday = scanner.nextLine();

        double hrPrice = 0;
        double roPrice = 0;
        double lalPrice = 0;
        double total = 0;

        if (season.equalsIgnoreCase("Spring") || season.equalsIgnoreCase("Summer")) {
            hrPrice = hrizantemi * 2;
            roPrice = rozi * 4.10;
            lalPrice = laleta * 2.50;
            total = hrPrice + roPrice + lalPrice;
            if (holiday.equalsIgnoreCase("y")) {
                total = total + (total * 0.15);
            }
            if (season.equalsIgnoreCase("spring") && laleta > 7) {
                total = total - (total * 0.05);
            }
            if (hrizantemi + rozi + laleta > 20) {
                total = total - (total * 0.2);
            }

        } else if (season.equalsIgnoreCase("winter") || season.equalsIgnoreCase("autumn")) {
            hrPrice = hrizantemi * 3.75;
            roPrice = rozi * 4.50;
            lalPrice = laleta * 4.15;
            total = hrPrice + roPrice + lalPrice;
            if (holiday.equalsIgnoreCase("y")) {
                total = total + (total * 0.15);
            }
            if (season.equalsIgnoreCase("winter") && rozi >= 10) {
                total = total - (total * 0.1);
            }
            if (hrizantemi + rozi + laleta > 20) {
                total = total - (total * 0.2);
            }
        }
        total = total + 2;
        System.out.printf("%.2f", total);
    }
}


