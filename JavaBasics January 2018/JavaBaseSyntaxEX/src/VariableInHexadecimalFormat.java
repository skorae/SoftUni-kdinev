import java.util.Scanner;

public class VariableInHexadecimalFormat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        System.out.println(hexToDec(input));

    }
    private static int hexToDec(String hex) {
        return Integer.parseInt(hex, 16);
    }
}
