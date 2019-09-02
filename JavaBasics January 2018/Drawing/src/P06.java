import java.util.Scanner;

public class P06 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        for (int row = 0; row < n; row++) {

            for (int col = 1; col < n - row; col++) {
                System.out.print(" ");
            }
            System.out.print("*");

            for (int col = 0; col < row; col++) {
                System.out.print(" *");
            }
            System.out.println("");
        }
        for (int row = 0; row < n - 1; row++) {
            for (int col = 0; col < row + 1; col++) {
                System.out.print(" ");
            }
            System.out.print("*");
            for (int i = 0; i < n - row - 2; i++) {
                System.out.print(" *");
            }
            System.out.println("");
        }
    }
}
