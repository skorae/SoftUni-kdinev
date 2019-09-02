import java.util.Scanner;

public class SumMulti {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int count = 0;

        for (int i = 1; i <= 30; i++) {
            for (int j = 1; j <= 30; j++) {
                for (int k = 1; k <= 30; k++) {

                    if (i < j && j < k && i + j + k == n) {
                        count++;
                        System.out.printf("%d + %d + %d = %d\n", i, j, k, n);
                    } else if (i > j && j > k && i * j * k == n) {
                        count++;
                        System.out.printf("%d * %d * %d = %d\n", i, j, k, n);
                    }
                }
            }
        }
        if (count == 0){
            System.out.println("No!");
        }
    }
}
