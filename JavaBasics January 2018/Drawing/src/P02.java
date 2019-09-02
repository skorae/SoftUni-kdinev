import java.util.Scanner;

public class P02 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        String FirsAndLastRow = "+";
        String MiddleRow = "|";

        for (int col = 0; col < n - 2; col++) {
            FirsAndLastRow += " -";
        }

        FirsAndLastRow += " +";
        System.out.println(FirsAndLastRow);

        for (int row = 0; row < n - 2; row++) {
            MiddleRow += " -";

        }
        MiddleRow += " |";
        for (int i = 0; i < n -2; i++) {
            System.out.println(MiddleRow);
        }
        System.out.println(FirsAndLastRow);
    }
}