import java.util.Scanner;

public class PiramidOfNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int num = Integer.parseInt(scanner.nextLine());
        int count = 1;

        for (int i = 1; i <= num; i++) {
            for (int j = 1; j <= i; j++) {
                System.out.printf("%d ", count);
                count++;
               if (count > num){
                   return;
               }
            }
            System.out.println();
        }
    }
}
