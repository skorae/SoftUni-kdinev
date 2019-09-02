import java.util.Scanner;

public class OperationsBetweenNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int N1 = Integer.parseInt(scanner.nextLine());
        int N2 = Integer.parseInt(scanner.nextLine());
        String operator = scanner.nextLine();

        switch (operator) {
            case "+":
                int result = N1 + N2;
                System.out.printf(result % 2 == 0 ? "%d %s %d = %d - even" : "%d %s %d = %d - odd", N1, operator, N2, result);
                break;
            case "-":
                int result1 = N1 - N2;
                System.out.printf(result1 % 2 == 0 ? "%d %s %d = %d - even" : "%d %s %d = %d - odd", N1, operator, N2, result1);
                break;
            case "*":
                int result2 = N1 * N2;
                System.out.printf(result2 % 2 == 0 ? "%d %s %d = %d - even" : "%d %s %d = %d - odd", N1, operator, N2, result2);
                break;
            case "/":
                double resultD = N1 * 1.0 / N2;
                System.out.printf(N2 == 0 ? "Cannot divide %d by zero" : "%d %s %d = %.2f", N1, operator, N2, resultD);
                break;
            case "%":
                double resultT = N1 * 1.0 % N2;
                System.out.printf(N2 == 0 ? "Cannot divide %d by zero" : "%d %s %d = %.0f", N1, operator, N2, resultT);
                break;
        }
    }
}