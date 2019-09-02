import java.util.Scanner;

public class ControlNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int m = Integer.parseInt(scanner.nextLine());
        int control = Integer.parseInt(scanner.nextLine());
        int summ = 0;
        int counter = 0;

        for (int i = 1; i <= n; i++) {
            for (int j = m; j >= 1; j--) {
                counter++;
                summ += (i * 2) + (j * 3);
                if (summ >= control) {
                    break;
                }
            }
        }
        if (summ >= control) {
            System.out.printf("%d moves\nScore: %d >= %d", counter, summ, control);
        } else if (summ < control)
            System.out.printf("%d moves", counter);
    }
}