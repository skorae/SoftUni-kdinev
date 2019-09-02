import java.util.Scanner;

public class primer_1 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double money = Double.parseDouble(scanner.nextLine());

        double result = money + 10.50;

        System.out.println(result);
    }
}
