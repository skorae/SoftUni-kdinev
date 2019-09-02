import java.util.Scanner;

public class P06 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int x = Integer.parseInt(scanner.nextLine());
        int y = Integer.parseInt(scanner.nextLine());
        int z = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i <= x; i++) {
            if (i % 2 == 0) {
                for (int j = 1; j <= y; j++) {
                    if (j == 2 || j == 3 || j == 5 || j == 7) {
                        for (int k = 1; k <= z; k++) {
                            if (k % 2 == 0) {

                                System.out.printf("%d %d %d \n", i, j, k);
                            }
                        }
                    }
                }
            }
        }
    }
}
