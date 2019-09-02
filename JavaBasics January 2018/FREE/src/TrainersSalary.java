import java.util.Scanner;

public class TrainersSalary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        double budget = Double.parseDouble(scanner.nextLine());
        double salary = budget / n;
        int countJelev = 0;
        int countRoYaL = 0;
        int countRoli = 0;
        int countTrofon = 0;
        int countSino = 0;
        int countOthers = 0;

        for (int i = 1; i <= n; i++) {
            String lector = scanner.nextLine();

            if (lector.equalsIgnoreCase("Jelev")) {
                countJelev++;
            } else if (lector.equalsIgnoreCase("royal")) {
                countRoYaL++;
            } else if (lector.equalsIgnoreCase("roli")) {
                countRoli++;
            } else if (lector.equalsIgnoreCase("trofon")) {
                countTrofon++;
            } else if (lector.equalsIgnoreCase("sino")) {
                countSino++;
            } else {
                countOthers++;
            }
        }
        System.out.printf("Jelev salary: %.2f lv\n", countJelev * salary);
        System.out.printf("RoYaL salary: %.2f lv\n", countRoYaL * salary);
        System.out.printf("Roli salary: %.2f lv\n", countRoli * salary);
        System.out.printf("Trofon salary: %.2f lv\n", countTrofon * salary);
        System.out.printf("Sino salary: %.2f lv\n", countSino * salary);
        System.out.printf("Others salary: %.2f lv", countOthers * salary);
    }
}
