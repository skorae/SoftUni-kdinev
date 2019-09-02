import java.util.Scanner;

public class P13 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int h = Integer.parseInt(scanner.nextLine());
        int x = Integer.parseInt(scanner.nextLine());
        int y = Integer.parseInt(scanner.nextLine());

        boolean isInsideX = ((x > 0 && x < 3 * h) && (y > 0 && y < h));
        boolean isInsideY = ((y > 0 && y < 4 * h) && (x > h && x < 2 * h));
        boolean isBorderX = ((x >= 0 && x <= 3 * h) && (y >= 0 && y <= h));
        boolean isBorderY = ((y >= 0 && y <= 4 * h) && (x >= h && x <= 2 * h));

        if (isInsideX || isInsideY) {
            System.out.println("inside");
        } else if (isBorderX || isBorderY) {
            System.out.println("border");
        } else{
            System.out.println("outside");
        }
    }
}