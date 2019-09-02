import java.util.Scanner;

public class Fox {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            String firstHalf = reapetsStr("*", 1 + i) + "\\"
                    + reapetsStr("-", ((n * 2) - 1) - 2 * i) + "/"
                    + reapetsStr("*", 1 + i);
            System.out.println(firstHalf);
        }
        for (int i = 0; i < n / 3; i++) {
            String middle = "|" + reapetsStr("*", (n / 2)+i)
                    + "\\" + reapetsStr("*", n - 2 * i) + "/"
                    + reapetsStr("*", (n / 2)+i) + "|";
            System.out.println(middle);
        }
        for (int i = 0; i < n; i++) {
            String secondHalf = reapetsStr("-", 1 + i) + "\\"
                    + reapetsStr("*", ((n * 2) - 1) - 2 * i) + "/"
                    + reapetsStr("-", 1 + i);
            System.out.println(secondHalf);

        }
    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}
