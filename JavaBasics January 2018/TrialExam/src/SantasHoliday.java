import java.util.Scanner;

public class SantasHoliday {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        String room = scanner.nextLine();
        String grade = scanner.nextLine();

        int sleep = days - 1;
        double cost = 0;
        double lowPrice = 0;
        double total = 0;

        if (days < 10) {
            if (room.equalsIgnoreCase("room for one person")) {
                cost = sleep * 18.00;
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            } else if (room.equalsIgnoreCase("apartment")) {
                lowPrice = 0.30;
                cost = (sleep * 25) - ((sleep * 25) * lowPrice);
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            } else if (room.equalsIgnoreCase("president apartment")) {
                lowPrice = 0.10;
                cost = (sleep * 35) - ((sleep * 35) * lowPrice);
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            }
        } else if (days <= 15) {
            if (room.equalsIgnoreCase("room for one person")) {
                cost = sleep * 18.00;
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            } else if (room.equalsIgnoreCase("apartment")) {
                lowPrice = 0.35;
                cost = (sleep * 25) - ((sleep * 25) * lowPrice);
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            } else if (room.equalsIgnoreCase("president apartment")) {
                lowPrice = 0.15;
                cost = (sleep * 35) - ((sleep * 35) * lowPrice);
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            }
        }else{
            if (room.equalsIgnoreCase("room for one person")) {
                cost = sleep * 18.00;
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            } else if (room.equalsIgnoreCase("apartment")) {
                lowPrice = 0.50;
                cost = (sleep * 25) - ((sleep * 25) * lowPrice);
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            } else if (room.equalsIgnoreCase("president apartment")) {
                lowPrice = 0.20;
                cost = (sleep * 35) - ((sleep * 35) * lowPrice);
                if (grade.equalsIgnoreCase("positive")) {
                    total = cost + (cost * 0.25);
                } else {
                    total = cost - (cost * 0.10);
                }
            }
        }
        System.out.printf("%.2f", total);
    }
}
