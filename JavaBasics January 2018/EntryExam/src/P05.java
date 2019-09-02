import java.util.Scanner;

public class P05 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        String space = "";

        String firstRow = reapetsStr("#", n - 1) + "/^\\"
                + reapetsStr("#", n - 1);
        System.out.println(firstRow);

        for (int i = 0; i < Math.floor(n / 2); i++) {

            String first = reapetsStr("#", (n - 2) - i)
                    + "." + reapetsStr(" ", 3 + i * 2) + "."
                    + reapetsStr("#", (n - 2) - i);
            System.out.println(first);
        }
        if (n % 2 == 0) {
            String s = reapetsStr("#", (int) Math.ceil((n / 2) - 1)) + "|"
                    + reapetsStr(" ", n / 2) + "S"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (int) Math.ceil((n / 2) - 1));
            System.out.println(s);

            String o = reapetsStr("#", (int) Math.ceil((n / 2) - 1)) + "|"
                    + reapetsStr(" ", n / 2) + "O"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (int) Math.ceil((n / 2) - 1));
            System.out.println(o);

            String f = reapetsStr("#", (int) Math.ceil((n / 2) - 1)) + "|"
                    + reapetsStr(" ", n / 2) + "F"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (int) Math.ceil((n / 2) - 1));
            System.out.println(f);

            String t = reapetsStr("#", (int) Math.ceil((n / 2) - 1)) + "|"
                    + reapetsStr(" ", n / 2) + "T"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (int) Math.ceil((n / 2) - 1));
            System.out.println(t);
        } else {
            String s = reapetsStr("#", (n / 2)) + "|"
                    + reapetsStr(" ", n / 2) + "S"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (n / 2));
            System.out.println(s);

            String o = reapetsStr("#", (n / 2)) + "|"
                    + reapetsStr(" ", n / 2) + "O"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (n / 2));
            System.out.println(o);

            String f = reapetsStr("#", (n / 2)) + "|"
                    + reapetsStr(" ", n / 2) + "F"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (n / 2));
            System.out.println(f);

            String t = reapetsStr("#", (n / 2)) + "|"
                    + reapetsStr(" ", n / 2) + "T"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (n / 2));
            System.out.println(t);
        }
        if (n % 2 == 0) {
            for (int i = 0; i < n / 3; i++) {
                space = reapetsStr("#", (int) Math.ceil((n / 2) - 1)) + "|"
                        + reapetsStr(" ", n / 2) + " "
                        + reapetsStr(" ", n / 2) + "|"
                        + reapetsStr("#", (int) Math.ceil((n / 2) - 1));
                System.out.println(space);
            }
        } else {
            if (n < 8) {
                for (int i = 0; i < n - 4; i++) {
                    space = reapetsStr("#", (n / 2)) + "|"
                            + reapetsStr(" ", n / 2) + " "
                            + reapetsStr(" ", n / 2) + "|"
                            + reapetsStr("#", (n / 2));
                    System.out.println(space);
                }
            } else {
                for (int i = 0; i <n - 4; i++) {
                    space = reapetsStr("#", (n / 2)) + "|"
                            + reapetsStr(" ", n / 2) + " "
                            + reapetsStr(" ", n / 2) + "|"
                            + reapetsStr("#", (n / 2));
                    System.out.println(space);
                }
            }
        }

        if (n % 2 == 0) {
            String u = reapetsStr("#", (int) Math.ceil((n / 2) - 1)) + "|"
                    + reapetsStr(" ", n / 2) + "U"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (int) Math.ceil((n / 2) - 1));
            System.out.println(u);

            String N = reapetsStr("#", (int) Math.ceil((n / 2) - 1)) + "|"
                    + reapetsStr(" ", n / 2) + "N"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (int) Math.ceil((n / 2) - 1));
            System.out.println(N);

            String I = reapetsStr("#", (int) Math.ceil((n / 2) - 1)) + "|"
                    + reapetsStr(" ", n / 2) + "I"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (int) Math.ceil((n / 2) - 1));
            System.out.println(I);
        } else {
            String u = reapetsStr("#", (n / 2)) + "|"
                    + reapetsStr(" ", n / 2) + "U"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (n / 2));
            System.out.println(u);

            String N = reapetsStr("#", (n / 2)) + "|"
                    + reapetsStr(" ", n / 2) + "N"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (n / 2));
            System.out.println(N);

            String I = reapetsStr("#", (n / 2)) + "|"
                    + reapetsStr(" ", n / 2) + "I"
                    + reapetsStr(" ", n / 2) + "|"
                    + reapetsStr("#", (n / 2));
            System.out.println(I);
        }
        String edge = "@" + reapetsStr("=", n * 2 - 1) + "@";
        System.out.println(edge);


        if (n % 2 == 0) {
            for (int i = 1; i <= (n / 2) + 1; i++) {
                if (i == (n / 2) + 1) {
                    String last = reapetsStr("#", n / 2 + 1) + "\\"
                            + reapetsStr(".", n - 3) + "/"
                            + reapetsStr("#", n / 2 + 1);
                    System.out.println(last);
                } else {
                    String last = reapetsStr("#", n / 2 + 1) + "|"
                            + reapetsStr(" ", n - 3) + "|"
                            + reapetsStr("#", n / 2 + 1);
                    System.out.println(last);
                }
            }
        } else {
            for (int i = 1; i <= (n / 2) + 1; i++) {
                if (i == (n / 2) + 1) {
                    String last = reapetsStr("#", n / 2 + 2) + "\\"
                            + reapetsStr(".", n - 4) + "/"
                            + reapetsStr("#", n / 2 + 2);
                    System.out.println(last);
                } else {
                    String last = reapetsStr("#", n / 2 + 2) + "|"
                            + reapetsStr(" ", n - 4) + "|"
                            + reapetsStr("#", n / 2 + 2);
                    System.out.println(last);
                }
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
