import java.util.Scanner;

public class P03 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char n = scanner.nextLine().charAt(0);
        int n1 = Integer.parseInt(scanner.nextLine());
        char m = scanner.nextLine().charAt(0);
        int m1 = Integer.parseInt(scanner.nextLine());
        char k = scanner.nextLine().charAt(0);
        int k1 = Integer.parseInt(scanner.nextLine());

        int N = n + n1;
        int M = m + m1;
        int K = k + k1;

        String result = "" + (char) N + (char) M + (char) K;

        if (result.equals("777")) {
            System.out.printf("%s\n", result);
            System.out.printf("*** JACKPOT ***");
        } else if (result.equals("@@@")) {
            System.out.printf("%s\n", result);
            System.out.printf("!!! YOU LOSE EVERYTHING !!!");
        } else {
            System.out.printf("%s", result);
        }
    }
}
