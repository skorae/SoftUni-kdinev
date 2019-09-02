import java.util.Scanner;

public class HousePainting {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double x = Double.parseDouble(scanner.nextLine());
        double y = Double.parseDouble(scanner.nextLine());
        double h = Double.parseDouble(scanner.nextLine());

        double front = (x * x) - (1.2 * 2);
        double back = x * x;
        double walls = ((x * y) - (1.5 * 1.5)) * 2;
        double roofSides = (x * y) * 2;
        double roofFB = ((x * h) / 2) * 2;

        double green = (front + back + walls) / 3.4;
        double red = (roofFB + roofSides) / 4.3;

        System.out.printf("%.2f\n%.2f", green, red);

    }
}
