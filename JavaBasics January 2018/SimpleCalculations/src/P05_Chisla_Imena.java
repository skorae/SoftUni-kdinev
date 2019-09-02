import java.util.Scanner;

public class P05_Chisla_Imena {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String firstName = scanner.nextLine();
        String lastName = scanner.nextLine();
        int age = Integer.parseInt(scanner.nextLine());
        String town = scanner.nextLine();

        System.out.printf("You are " + firstName +" " + lastName + ", a " + age + "years old pearson from " + town );
    }

    }