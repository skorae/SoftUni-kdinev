import java.util.Scanner;

public class HousePrice {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double smallesrRoom = Double.parseDouble(scanner.nextLine());
        double kitchen = Double.parseDouble(scanner.nextLine());
        double pricePerSquare = Double.parseDouble(scanner.nextLine());

        double bathroom = smallesrRoom * 0.5;
        double secondRoom = smallesrRoom + (smallesrRoom * 0.1);
        double thirdRoom = secondRoom + (secondRoom * 0.1);
        double area = kitchen + bathroom + secondRoom + thirdRoom + smallesrRoom;
        double allArea = area + (area * 0.05);
        double price = allArea * pricePerSquare;

        System.out.printf("%.2f", price);
    }
}
