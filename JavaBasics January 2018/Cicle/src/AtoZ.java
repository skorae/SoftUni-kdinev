import java.util.Scanner;

public class AtoZ {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numbCount = Integer.parseInt(scanner.nextLine());
        int sum = 0;

        for (int i = 0; i < numbCount; i++) {
            int currentNumber = Integer.parseInt(scanner.nextLine());

            //sum = sum + currentNumber
            sum += currentNumber;
        }
        System.out.println(sum);
    }
}
