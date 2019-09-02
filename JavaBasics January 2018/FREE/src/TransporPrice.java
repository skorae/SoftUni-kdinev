import java.util.Scanner;

public class TransporPrice {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        String time = scanner.nextLine();

        double taxiDay = 0.70 + n * 0.79;
        double taxiNight = 0.70 + n * 0.90;
        double busPrice = n * 0.09;
        double trainPrice = n * 0.06;

        if (time.equalsIgnoreCase("day")) {
            if (n < 20) {
                System.out.printf("%.2f", taxiDay);
            } else if (n < 100) {
                System.out.printf("%.2f", busPrice);
            } else System.out.printf("%.2f", trainPrice);
        } else if (time.equalsIgnoreCase("night")) {
            if (n < 20) {
                System.out.printf("%.2f", taxiNight);
            } else if (n < 100) {
                System.out.printf("%.2f", busPrice);
            } else {
                System.out.printf("%.2f", trainPrice);
            }
        }
    }
}
