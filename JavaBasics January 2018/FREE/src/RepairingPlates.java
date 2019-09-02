import java.util.Scanner;

public class RepairingPlates {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int N = Integer.parseInt(scanner.nextLine());
        double W = Double.parseDouble(scanner.nextLine());
        double L = Double.parseDouble(scanner.nextLine());
        int M = Integer.parseInt(scanner.nextLine());
        int O = Integer.parseInt(scanner.nextLine());

        int area = N * N;
        double plateArea = W * L;
        int benchArea = M * O;

        double platesArea = area - benchArea;
        double allPlates = platesArea / plateArea;
        double time = allPlates * 0.2;

        System.out.printf("%.2f%n%.2f", allPlates, time);
    }
}
