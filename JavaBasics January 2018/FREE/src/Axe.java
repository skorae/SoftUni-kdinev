import java.util.Scanner;

public class Axe {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());


        for (int i = 0; i < n; i++) {
            String first = reapetsStr("-", 3 * n) + "*"
                    + reapetsStr("-", i) + "*"
                    + reapetsStr("-", ((n * 2) - 2) - i);
            System.out.println(first);
        }

        for (int i = 0; i < n / 2; i++) {
            String handle = reapetsStr("*", 3 * n) + "*"
                    + reapetsStr("-", n - 1) + "*"
                    + reapetsStr("-", n - 1);
            System.out.println(handle);
        }
        for (int i = 0; i < (n / 2); i++) {
            String end = "";
            if (i == (n / 2) - 1){
                end = reapetsStr("-", (n * 3) - i) + "*"
                        + reapetsStr("*", (n - 1) + 2 * i) + "*"
                        + reapetsStr("-", (n - 1) - i);
                System.out.println(end);
            }else {
                end = reapetsStr("-", (n * 3) - i) + "*"
                        + reapetsStr("-", (n - 1) + 2 * i) + "*"
                        + reapetsStr("-", (n - 1) - i);
                System.out.println(end);
            }
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
