import java.util.Scanner;

public class Elements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        int maxNum = Integer.MIN_VALUE;
        int sum = 0;

        for (int i = 0; i < n; i++) {
            int currentNumber = Integer.parseInt(scanner.nextLine());

            if (currentNumber > maxNum) {
                maxNum = currentNumber;
            }

            sum += currentNumber;
        }
        if (sum - maxNum == maxNum) {
            System.out.println("Yes Sum = " + maxNum);
        } else {
            System.out.println("No Diff = " + Math.abs(sum - maxNum - maxNum));
        }
    }
}
