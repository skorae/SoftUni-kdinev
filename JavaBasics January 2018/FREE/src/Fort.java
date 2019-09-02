import java.util.Scanner;

public class Fort {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        int spaces = 0;

        if (n < 5) {
            spaces = 0;
        } else if (n % 2 == 0) {
            spaces = (n * 2) - (n + 4);
        } else {
            spaces = (n * 2) - (n + 4) + 1;
        }

        String firstRow = "/" + reapetsStr("^", n / 2) + "\\"
                + reapetsStr("_", spaces) + "/"
                + reapetsStr("^", n / 2) + "\\";
        System.out.println(firstRow);


        if (n < 5) {
            for (int i = 0; i < n - 2; i++) {

                String middleRows = "|" + reapetsStr(" ", (n * 2) - 2) + "|";
                System.out.println(middleRows);
            }
        } else {
            for (int i = 0; i < n - 3; i++) {

                String middleRows = "|" + reapetsStr(" ", (n * 2) - 2) + "|";
                System.out.println(middleRows);
            }
            String exeption = "|" + reapetsStr(" ", n / 2) + " "
                    + reapetsStr("_", spaces) + " "
                    + reapetsStr(" ", n / 2) + "|";
            System.out.println(exeption);
        }

        String lastRow = "\\" + reapetsStr("_", n / 2) + "/"
                + reapetsStr(" ", spaces) + "\\"
                + reapetsStr("_", n / 2) + "/";
        System.out.println(lastRow);
    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}