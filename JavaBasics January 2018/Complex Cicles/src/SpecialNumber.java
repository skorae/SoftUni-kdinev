import java.util.Scanner;

public class SpecialNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        for (int d1 = 1; d1 <= 9; d1++) {
            if (n % d1 == 0) {
                for (int d2 = 1; d2 <= 9; d2++) {
                    if (n % d2 == 0) {
                        for (int d3 = 1; d3 <= 9; d3++) {
                            if (n % d3 == 0) {
                                for (int d4 = 1; d4 <= 9; d4++) {
                                    if (n % d4 == 0) {
                                        System.out.print("" + d1 + d2 + d3 + d4 + " ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}