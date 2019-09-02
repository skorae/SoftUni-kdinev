import java.util.Scanner;

public class Grades {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int count = 0;
        double fail = 0;
        double lowgrade = 0;
        double average = 0;
        double exellent = 0;
        double totalgrade = 0;

        for (int i = 0; i < n; i++) {
            double studentGrade = Double.parseDouble(scanner.nextLine());

            if (studentGrade < 3) {
                fail++;
            } else if (studentGrade < 4) {
                lowgrade++;
            } else if (studentGrade < 5) {
                average++;
            } else {
                exellent++;
            }

            totalgrade += studentGrade / n;
        }
        System.out.printf("Top students: %.2f%%\n", (exellent * 1.0) / n * 100);
        System.out.printf("Between 4.00 and 4.99: %.2f%%\n", (average * 1.0 ) / n * 100);
        System.out.printf("Between 3.00 and 3.99: %.2f%%\n", (lowgrade* 1.0 )  / n * 100);
        System.out.printf("Fail: %.2f%%\n", (fail * 1.0) / n * 100);
        System.out.printf("Average: %.2f", totalgrade);
    }
}
