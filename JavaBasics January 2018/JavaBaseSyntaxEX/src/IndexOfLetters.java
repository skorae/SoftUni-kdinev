import java.util.Arrays;
import java.util.Scanner;

public class IndexOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        char[] temp = new char[input.length()];
        temp = input.toCharArray();

        for (char c:temp
             ) {
            System.out.printf("%c -> %d%n", c , (int) c - 97);
        }

    }
}
