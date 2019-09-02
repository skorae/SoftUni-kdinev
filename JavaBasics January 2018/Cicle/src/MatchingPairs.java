import java.util.Scanner;

public class MatchingPairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int previosSum = 0;
        int currentSum = 0;
        int difference = 0;
        int biggestDiff = 0;

        for (int i = 0; i < n; i++) {
            int firrstNum = Integer.parseInt(scanner.nextLine());
            int secondNum = Integer.parseInt(scanner.nextLine());

            if (i == 0) {
                previosSum = firrstNum + secondNum;
            } else {
                currentSum = firrstNum + secondNum;

                difference = Math.abs(previosSum - currentSum);
            }
            if (difference > biggestDiff) {
                biggestDiff = difference;
            }
            previosSum = currentSum;
        }
        if (biggestDiff == 0) {
            System.out.printf("Yes, value = %d", currentSum);
        } else {
            System.out.printf("No, maxdiff = %d", difference);
        }
    }
}