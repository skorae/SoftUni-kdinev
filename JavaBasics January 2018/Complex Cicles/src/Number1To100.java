import java.util.Scanner;

public class Number1To100 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int number = Integer.parseInt(scanner.nextLine());
        System.out.println("Enter a number in the range [1...100]:");

        while (number < 1 || number > 100){
            System.out.println("Invalid number!");
            System.out.print("Enter a number in the range [1...100]:");

            number = Integer.parseInt(scanner.nextLine());
        }

        System.out.println("The number is:" + number);
    }
}
