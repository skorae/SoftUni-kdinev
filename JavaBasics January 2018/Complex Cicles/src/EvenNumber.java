import java.util.Scanner;

public class EvenNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        while (true) {
            try {
                System.out.println("Enter even number: ");
                int num = Integer.parseInt(scanner.nextLine());
                if (num % 2 == 0) {
                    System.out.printf("Even number entered: %d", num);
                    break;
                } else {
                    System.out.println("The number is not even.");
                }
            } catch (Exception ex) {
                System.out.println("Invalid number!");
            }
        }
    }
}