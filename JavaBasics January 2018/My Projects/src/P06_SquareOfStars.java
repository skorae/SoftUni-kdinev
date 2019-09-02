import java.util.Scanner;

public class P06_SquareOfStars {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        String firstAndLastRow = "";

        for (int i = 1; i <= n; i++) {
            firstAndLastRow = firstAndLastRow + "*";
        }
        System.out.println(firstAndLastRow);

        for (int i = 0; i < n - 2; i++) {
            String middleRow = "*";
            for (int j = 0; j < n - 2; j++) {
                middleRow = middleRow + " ";
            }
            middleRow = middleRow + "*";
            System.out.println(middleRow);
        }
        System.out.println(firstAndLastRow);
    }
}