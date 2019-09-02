import java.util.Scanner;

public class LeftAndRight {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int sum1 = 0;
        int sum2 = 0;

        for (int i = 0; i < n; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            sum1 = sum1 + number;
        }
        for (int i = 0; i < n; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            sum2 = sum2 + number;
        }
        if (sum1 == sum2) {
            System.out.println("Yes, sum" + "=" + sum1);
        } else {
            int dif = Math.abs(sum1 - sum2);
            System.out.println("No, diff" + "=" + dif);
        }
    }
}
