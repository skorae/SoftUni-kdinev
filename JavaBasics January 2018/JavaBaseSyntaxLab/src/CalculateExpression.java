import java.util.Scanner;

public class CalculateExpression {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double a = ((30 + 21) * 1.0 * (1.0 / 2) * ((35 - 12) * 1.0 - 1.0 / 2));

        System.out.println(Math.pow(a, 2));
    }
}
