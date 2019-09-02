import java.util.Scanner;

public class P02 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String product = scanner.nextLine();
        String city = scanner.nextLine();
        double quantity = Double.parseDouble(scanner.nextLine());
        double price = 0;


        if (city.equalsIgnoreCase("Sofia")) {
            if (product.equalsIgnoreCase("coffee")) {
                price = 0.5;
            } else if (product.equalsIgnoreCase("water")) {
                price = 0.8;
            } else if (product.equalsIgnoreCase("beer")) {
                price = 1.2;
            } else if (product.equalsIgnoreCase("sweets")) {
                price = 1.45;

            } else if (product.equalsIgnoreCase("peanuts")) {
                price = 1.60;
            }


        } else if (city.equalsIgnoreCase("Plovdiv")) {
            if (product.equalsIgnoreCase("coffee")) {
                price = 0.4;
            } else if (product.equalsIgnoreCase("water")) {
                price = 0.7;
            } else if (product.equalsIgnoreCase("beer")) {
                price = 1.15;
            } else if (product.equalsIgnoreCase("sweets")) {
                price = 1.30;

            } else if (product.equalsIgnoreCase("peanuts")) {
                price = 1.50;
            }


        } else if (city.equalsIgnoreCase("Varna"))

        {
            if (product.equalsIgnoreCase("coffee")) {
                price = 0.45;
            } else if (product.equalsIgnoreCase("water")) {
                price = 0.7;
            } else if (product.equalsIgnoreCase("beer")) {
                price = 1.10;
            } else if (product.equalsIgnoreCase("sweets")) {
                price = 1.35;

            } else if (product.equalsIgnoreCase("peanuts")) {
                price = 1.55;
            }
        }
        double result = price * quantity;

        System.out.println(result);
    }
}
