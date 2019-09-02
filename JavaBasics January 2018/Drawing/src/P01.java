import java.util.Scanner;

public class P01 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        for (int row = 1; row < n; row++) {
            System.out.print("*");
            for (int i = 0; i < n; i++) {
                System.out.print(" *");
            }
            System.out.println("");

        }
    }
}
