import java.util.Scanner;

public class P07 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        for (int row = 0; row < n + 1; row++) {
            String spaces = "";
            for (int i = 0; i < n - row; i++) {
                System.out.print(" ");
            }
            System.out.println(spaces);

        }
    }
}
