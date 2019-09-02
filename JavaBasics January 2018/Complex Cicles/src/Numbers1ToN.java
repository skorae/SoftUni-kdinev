import java.util.Scanner;

public class Numbers1ToN {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int number = 1;

        for (int i = 1; i <= n; i++) {
            System.out.println(number);
            number = number * 4;
        }
    }
}