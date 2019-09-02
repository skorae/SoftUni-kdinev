import java.util.Scanner;

public class Factoriel {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int num = 1;

        for (int i = 1; i <= n; i++) {
             num *=i;
        }
        System.out.println(num);
    }
}
