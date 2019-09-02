import java.util.Scanner;

public class P11 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String type = scanner.nextLine();
        int row = Integer.parseInt(scanner.nextLine());
        int collumn = Integer.parseInt(scanner.nextLine());
        double price = 0;

        if (type.equalsIgnoreCase("Premiere")) {
            price = 12;
        } else if (type.equalsIgnoreCase("Normal")) {
            price = 7.5;
        } else if (type.equalsIgnoreCase("Discount")) {
            price = 5.00;
        }
        double income = row * collumn * price;
        System.out.printf("%.2f", income);
    }
}
