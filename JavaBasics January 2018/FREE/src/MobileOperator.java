import java.util.Scanner;

public class MobileOperator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String period = scanner.nextLine().toLowerCase();
        String type = scanner.nextLine().toLowerCase();
        String internet = scanner.nextLine().toLowerCase();
        int months = Integer.parseInt(scanner.nextLine());
        double tax = 0;

        if (period.equals("one")) {
            if (type.equals("small")) {
                if (internet.equals("yes")) {
                    tax = 9.98 + 5.50;
                } else {
                    tax = 9.98;
                }
            } else if (type.equals("middle")) {
                if (internet.equals("yes")) {
                    tax = 18.99 + 4.35;
                } else {
                    tax = 19.99;
                }
            } else if (type.equals("large")) {
                if (internet.equals("yes")) {
                    tax = 25.98 + 4.35;
                } else {
                    tax = 25.98;
                }
            } else if (type.equals("extralarge")) {
                if (internet.equals("yes")) {
                    tax = 35.99 + 3.85;
                } else {
                    tax = 35.99;
                }
            }
        } else {
            if (type.equals("small")) {
                if (internet.equals("yes")) {
                    tax = (8.58 + 5.50) * 0.9625;
                } else {
                    tax = 8.58 * 0.9625;
                }
            } else if (type.equals("middle")) {
                if (internet.equals("yes")) {
                    tax = (17.09 + 4.35) * 0.9625;
                } else {
                    tax = 17.09 * 0.9625;
                }
            } else if (type.equals("large")) {
                if (internet.equals("yes")) {
                    tax = (23.59 + 4.35) * 0.9625;
                } else {
                    tax = 23.59 * 0.9625;
                }
            } else if (type.equals("extralarge")) {
                if (internet.equals("yes")) {
                    tax = (31.79 + 3.85) * 0.9625;
                } else {
                    tax = 31.79 * 0.9625;
                }
            }
        }
        double total = tax * months;
        System.out.printf("%.2f lv.", total);
    }
}
