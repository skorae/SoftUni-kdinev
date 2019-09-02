import java.util.Scanner;

public class ChristmasToy {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());


        String firstAndLastRow = reapetsStr("-", n * 2)
                + reapetsStr("*", n)
                + reapetsStr("-", n * 2);
        System.out.println(firstAndLastRow);


        String middleRow = reapetsStr("-", n / 2) + "*"
                + reapetsStr("|", (n * 4) - 2) + "*"
                + reapetsStr("-", n / 2);

        for (int i = 0; i < n / 2; i++) {
            String bodyUpper1 = reapetsStr("-", ((2 * n) - 2) - (2 * i))
                    + reapetsStr("*", 1 + i)
                    + reapetsStr("&", (n + 2) + 2 * i)
                    + reapetsStr("*", 1 + i)
                    + reapetsStr("-", ((2 * n) - 2) - (2 * i));
            System.out.println(bodyUpper1);
        }

        for (int i = 0; i < n / 2; i++) {
            String bodyUpper2 = reapetsStr("-", (n - 1) - i) + "**"
                    + reapetsStr("~", ((n * 3) - 2) + 2 * i) + "**"
                    + reapetsStr("-", (n - 1) - i);
            System.out.println(bodyUpper2);
        }
        System.out.println(middleRow);

        for (int i = 0; i < n / 2; i++) {
            String bodyLower1 = reapetsStr("-", (n / 2) + i) + "**"
                    + reapetsStr("~", (4 * n - 4) - 2 * i) + "**"
                    + reapetsStr("-", (n / 2) + i);
            System.out.println(bodyLower1);
        }

        for (int i = 0; i < n / 2; i++) {
            String bodyLower2 = reapetsStr("-", n + 2 * i)
                    + reapetsStr("*", n / 2 - i)
                    + reapetsStr("&", 2 * n - 2 * i)
                    + reapetsStr("*", n / 2 - i)
                    + reapetsStr("-", n + 2 * i);
            System.out.println(bodyLower2);
        }

        System.out.println(firstAndLastRow);
    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}
