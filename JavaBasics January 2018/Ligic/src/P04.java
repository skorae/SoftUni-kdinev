import java.util.Scanner;

public class P04 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Enter two integers:");
        int number = Integer.parseInt(scanner.nextLine());
        int otherNumber = Integer.parseInt(scanner.nextLine());

        if (number > otherNumber) {
            System.out.printf("Greater number: %d", number);
        } else {
            System.out.printf("Greater number: %d", otherNumber);

        }
    }
}