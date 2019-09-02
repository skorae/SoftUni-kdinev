import java.util.Scanner;

public class GradesWhile {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int studenCount = Integer.parseInt(scanner.nextLine());
        int topStudent = 0;
        int between4And5Student = 0;
        int between3And4Student = 0;
        int failStudent = 0;
        int counterWhile = studenCount;
        double grades = 0;

        while (true) {
            double grade = Double.parseDouble(scanner.nextLine());
            grades += grade;

            if (grade < 3) {
                failStudent++;
            } else if (grade < 4) {
                between3And4Student++;
            } else if (grade < 5) {
                between4And5Student++;
            } else {
                topStudent++;
            }
            counterWhile--;
            if (counterWhile == 0) {
                break;
            }
        }
        System.out.printf("Top students: %.2f%%\n", topStudent * 1.0 * 100 / studenCount);
        System.out.printf("Between 4.00 and 4.99: %.2f%%\n", between4And5Student * 1.0 * 100 / studenCount);
        System.out.printf("Between 3.00 and 3.99: %.2f%%\n", between3And4Student * 1.0 * 100 / studenCount);
        System.out.printf("Fail: %.2f%%\n", failStudent * 1.0 * 100 / studenCount);
        System.out.printf("Average: %.2f", grades / studenCount);
    }
}
