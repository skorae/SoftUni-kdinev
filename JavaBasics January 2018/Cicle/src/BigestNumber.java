import java.util.Scanner;

public class BigestNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int count = Integer.parseInt(scanner.nextLine());
        int maxNumber = Integer.MIN_VALUE;

        for (int i = 0; i < count; i++) {
            int currentNumber = Integer.parseInt(scanner.nextLine());

            if (currentNumber > maxNumber){
                maxNumber = currentNumber;
            }
        }
        System.out.println(maxNumber);
    }
}
