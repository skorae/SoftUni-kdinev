import java.util.Scanner;

public class MatchTickets {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String category = scanner.nextLine();
        int people = Integer.parseInt(scanner.nextLine());

        double VIPthicket = 499.99;
        double normalThicket = 249.99;
        double transportMoney = 0;

        if (people <= 4) {
            transportMoney = budget * 0.75;
        } else if (people <= 9) {
            transportMoney = budget * 0.60;
        } else if (people <= 24) {
            transportMoney = budget * 0.50;
        } else if (people <= 49) {
            transportMoney = budget * 0.40;
        } else if (people >= 50){
            transportMoney = budget * 0.25;
        }
        double moneyLeft = budget - transportMoney;

        if (category.equalsIgnoreCase("vip")) {
            double ticket = people * VIPthicket;
            double totalMoney = moneyLeft - ticket;
            if (budget < (ticket + transportMoney)) {
                double moneyNeeded = (ticket + transportMoney) - budget;
                System.out.printf("Not enough money! You need %.2f leva.", moneyNeeded);
            } else {
                System.out.printf("Yes! You have %.2f leva left.", totalMoney);
            }

        }else if (category.equalsIgnoreCase("normal")) {
            double ticket = people * normalThicket;
            double totalMoney = moneyLeft - ticket;
            if (budget < (ticket + transportMoney)) {
                double moneyNeeded = (ticket + transportMoney) - budget;
                System.out.printf("Not enough money! You need %.2f leva.", moneyNeeded);
            } else {
                System.out.printf("Yes! You have %.2f leva left.", totalMoney);
            }
        }
    }
}