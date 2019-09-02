import java.util.Scanner;

public class GrandpaStavri {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        double allLitters = 0;
        double averageGradus = 0;
        double count = 0;
        double totalgradus = 0;

        for (int i = 0; i < n; i++) {
            double litters = Double.parseDouble(scanner.nextLine());
            double gradus = Double.parseDouble(scanner.nextLine());

            allLitters += litters;
            count++;
            averageGradus += gradus * litters;

            totalgradus = averageGradus / allLitters;

        }
        System.out.printf("Liter: %.2f\n", allLitters);
        System.out.printf("Degrees: %.2f\n", totalgradus);

        if (totalgradus < 38) {
            System.out.println("Not good, you should baking!");
        } else if (totalgradus <= 42) {
            System.out.printf("Super!");
        } else {
            System.out.println("Dilution with distilled water!");
        }
    }
}
