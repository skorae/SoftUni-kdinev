import java.util.Scanner;

public class MIlesToKilometers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double a = Double.parseDouble(scanner.nextLine());
        double sum = a * 1.60934;

        System.out.printf("%.2f", sum);

    }
}
