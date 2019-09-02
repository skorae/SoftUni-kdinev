import java.util.Scanner;

public class Fibonacci {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int f1 = 1;
        int f2 = 1;

        for (int i = 1; i < n; i++) {
            int temp = f1;
            f1 = f2;
            f2 = temp + f1;


        }
        System.out.println(f2);
    }
}
