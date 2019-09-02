import java.util.Scanner;

public class P01_ {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int years = Integer.parseInt(scanner.nextLine()); // 5

        int result = years + 20;

        System.out.println(result);
    }
}