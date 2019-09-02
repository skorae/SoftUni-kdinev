import java.util.Scanner;

public class EvenOdd_Summ {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int oddSum = 0;
        int evenSum = 0;

        for (int i = 0; i < n; i++) {
            int number = Integer.parseInt(scanner.nextLine());

            if (i % 2 == 0) {
                evenSum += number;
            }else{
                oddSum += number;
            }
        }
        if (oddSum == evenSum){
            System.out.printf("Yes%nSum = %d", oddSum);
        }else{
            System.out.printf("No%nDiff = %d", Math.abs(oddSum - evenSum));
        }
    }
}
