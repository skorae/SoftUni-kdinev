import java.util.Scanner;

public class ReverseStrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();
        String reverse = new StringBuffer(text).reverse().toString();
        System.out.println(reverse);
    }
}
