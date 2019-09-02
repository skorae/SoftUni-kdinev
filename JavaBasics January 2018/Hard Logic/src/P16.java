import java.util.Scanner;

public class P16 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int N1 = Integer.parseInt(scanner.nextLine());
        int N2 = Integer.parseInt(scanner.nextLine());
        String operator = scanner.nextLine();

        if (operator.equals("+")) {
            int result = N1 + N2;
            if (result % 2 == 0) {
                System.out.printf("%d %s %d = %d - even", N1, operator, N2, result);
            } else {
                System.out.printf("%d %s %d = %d - odd", N1, operator, N2, result);
            }

        } else if (operator.equals("-")) {
            int result = N1 - N2;
            if (result % 2 == 0) {
                System.out.printf("%d %s %d = %d - even", N1, operator, N2, result);
            } else {
                System.out.printf("%d %s %d = %d - odd", N1, operator, N2, result);
            }
        } else if (operator.equals("*")) {
            int result = N1 * N2;
            if (result % 2 == 0) {
                System.out.printf("%d %s %d = %d - even", N1, operator, N2, result);
            } else {
                System.out.printf("%d %s %d = %d - odd", N1, operator, N2, result);
            }
        } else if (operator.equals("/")) {
            if (N2 == 0) {
                System.out.printf("Cannot divide %d by zero", N1);
            } else {
                double result = N1 * 1.0 / N2;
                System.out.printf("%d %s %d = %.2f", N1, operator, N2, result);
            }
        } else if (operator.equals("%")) {
            if (N2 > 0) {
                int result = N1 % N2;
                System.out.printf("%d %s %d = %d", N1, operator, N2, result);
            } else {
                System.out.printf("Cannot divide %d by zero", N1);
            }
        }
    }
}
