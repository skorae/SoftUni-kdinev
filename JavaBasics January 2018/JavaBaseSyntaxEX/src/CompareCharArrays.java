import java.util.Scanner;

public class CompareCharArrays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String first = scanner.nextLine().replace(" ", "");
        String second = scanner.nextLine().replace(" ", "");

        if (first.length() > second.length()) {
            String temp = first;
            first = second;
            second = temp;
        }

        for (int i = 0; i < first.length(); i++) {
            if (first.charAt(i) > second.charAt(i)) {
                String temp = first;
                first = second;
                second = temp;
                break;
            }
        }
        System.out.println(first);
        System.out.println(second);
    }
}
