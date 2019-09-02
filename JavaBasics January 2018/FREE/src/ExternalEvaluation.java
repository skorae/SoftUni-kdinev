import java.util.Scanner;

public class ExternalEvaluation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int poor = 0;
        int satis = 0;
        int good = 0;
        int verygood = 0;
        int excelent = 0;

        for (int i = 0; i < n; i++) {
            double grade = Double.parseDouble(scanner.nextLine());

            if (grade < 22.5) {
                poor++;
            } else if (grade < 40.5) {
                satis++;
            } else if (grade < 58.5) {
                good++;
            } else if (grade < 76.5) {
                verygood++;
            } else {
                excelent++;
            }
        }
        System.out.printf("%.2f%% poor marks\n", poor * 1.0 * 100 / n);
        System.out.printf("%.2f%% satisfactory marks\n", satis * 1.0 * 100 / n);
        System.out.printf("%.2f%% good marks\n", good * 1.0 * 100 / n);
        System.out.printf("%.2f%% very good marks\n", verygood * 1.0 * 100 / n);
        System.out.printf("%.2f%% excellent marks", excelent * 1.0 * 100 / n);
    }
}
