import java.util.Scanner;

public class P06 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double x1 = Double.parseDouble(scanner.nextLine());
        double y1 = Double.parseDouble(scanner.nextLine());
        double x2 = Double.parseDouble(scanner.nextLine());
        double y2 = Double.parseDouble(scanner.nextLine());
        double x = Double.parseDouble(scanner.nextLine());
        double y = Double.parseDouble(scanner.nextLine());

        boolean isBorderX = x == x1 || x == x2;
        boolean isBorderY = y == y1 || y == y2;
        boolean isBorderX1 = y >= y1 && y <= y2;
        boolean isBorderY1 = x >= x1 && x <= x2;


        if ((isBorderX && isBorderX1) || (isBorderY && isBorderY1)) {
            System.out.println("Border");
        } else {
            System.out.println("Inside / Outside");
        }
    }
}