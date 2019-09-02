import java.util.Scanner;

public class Crown {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        String middle = "";
        String beforeLast = "";

        String firstRow = "@" + reapetsStr(" ", n - 2) + "@" + reapetsStr(" ", n - 2) + "@";
        System.out.println(firstRow);

        if (n % 2 == 0) {
            for (int i = 0; i < n / 2; i++) {
                if (i == 0) {
                    middle = "*" + reapetsStr(".", i) + "*"
                            + reapetsStr(" ", n - 3) + "*"
                            + reapetsStr(" ", n - 3) + "**";
                    System.out.println(middle);
                } else if (i == (n / 2) - 1) {
                    middle = "*" + reapetsStr(".", i) + "*"
                            + reapetsStr(".", (1 + (2 * i)) - 2)
                            + "*" + reapetsStr(".", i) + "*";
                    System.out.println(middle);
                } else {
                    middle = "*" + reapetsStr(".", i) + "*"
                            + reapetsStr(" ", (n - 3) - 2 * i) + "*"
                            + reapetsStr(".", (1 + (2 * i)) - 2) + "*"
                            + reapetsStr(" ", (n - 3) - 2 * i)
                            + "*" + reapetsStr(".", i) + "*";
                    System.out.println(middle);
                }
            }

        } else {
            for (int i = 0; i < Math.ceil(n / 2); i++) {
                if (i == 0) {
                    middle = "*" + reapetsStr(".", i) + "*"
                            + reapetsStr(" ", n - 3) + "*"
                            + reapetsStr(" ", n - 3) + "**";
                    System.out.println(middle);
                } else if (i == Math.ceil(n / 2)) {
                    middle = "*" + reapetsStr(".", i) + "*"
                            + reapetsStr(".", (1 + (2 * i)) - 2)
                            + "*" + reapetsStr(".", i) + "*";
                    System.out.println(middle);
                } else {
                    middle = "*" + reapetsStr(".", i) + "*"
                            + reapetsStr(" ", (n - 3) - 2 * i) + "*"
                            + reapetsStr(".", (1 + (2 * i)) - 2) + "*"
                            + reapetsStr(" ", (n - 3) - 2 * i)
                            + "*" + reapetsStr(".", i) + "*";
                    System.out.println(middle);
                }
            }
        }
        if (n % 2 == 0) {
            beforeLast = "*" + reapetsStr(".", n / 2)
                    + reapetsStr("*", (n / 2) - 2) + "."
                    + reapetsStr("*", (n / 2) - 2)
                    + reapetsStr(".", n / 2) + "*";
            System.out.println(beforeLast);
        } else {
            beforeLast = "*" + reapetsStr(".", n / 2)
                    + reapetsStr("*", (n / 2) - 1) + "."
                    + reapetsStr("*", (n / 2) - 1)
                    + reapetsStr(".", n / 2) + "*";
            System.out.println(beforeLast);
        }
        for (int i = 0; i < 2; i++) {
            String lastRow = reapetsStr("*", (2 * n) - 1);
            System.out.println(lastRow);
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
