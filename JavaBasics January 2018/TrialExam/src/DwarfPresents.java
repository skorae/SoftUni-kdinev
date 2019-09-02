import java.util.Scanner;

public class DwarfPresents {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int dwarfs = Integer.parseInt(scanner.nextLine());
        int money = Integer.parseInt(scanner.nextLine());
        double sum = 0;

        for (int i = 1; i <= dwarfs; i++) {
            String typePresent = scanner.nextLine();

            if (typePresent.equalsIgnoreCase("sand clock")) {
                sum += 2.20;
            } else if (typePresent.equalsIgnoreCase("cup")) {
                sum += 5.0;
            } else if (typePresent.equalsIgnoreCase("magnet")) {
                sum += 1.50;
            } else if (typePresent.equalsIgnoreCase("t-shirt")) {
                sum += 10.0;
            }
        }

        if (money >= sum) {
            double diff = money - sum;
            System.out.printf("Santa Claus has %.2f more leva left!", diff);
        } else {
            double diff = sum - money;
            System.out.printf("Santa Claus will need %.2f more leva.", diff);
        }
    }
}