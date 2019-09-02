import java.sql.SQLOutput;
import java.util.Scanner;

public class Castle {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        String firstRow = "";
        String middleRows = "";
        String lastRow = "";
        String exeption = "";
        int diff = n * 2 - ((n / 2) + (n / 2) + (n / 2) + 4);

        if (n < 5) {
            firstRow = "/" + reapetsStr("^", n / 2)
                    + "\\" + "/" + reapetsStr("^", n / 2) + "\\";
        } else if (n >= 5 && (n / 2) + (n / 2) + (n / 2) + 4 < n * 2) {
            firstRow = "/" + reapetsStr("^", n / 2)
                    + "\\" + reapetsStr("_", n / 2 + diff)
                    + "/" + reapetsStr("^", n / 2)
                    + "\\";
        } else {
            firstRow = "/" + reapetsStr("^", n / 2)
                    + "\\" + reapetsStr("_", n / 2)
                    + "/" + reapetsStr("^", n / 2)
                    + "\\";
        }
        System.out.println(firstRow);


        if (n < 5) {
            for (int i = 1; i <= n - 2; i++) {
                middleRows = "|" + reapetsStr(" ", n * 2 - 2) + "|";
                System.out.println(middleRows);
            }

        } else if (n >= 5 && (n / 2) + (n / 2) + (n / 2) + 4 < n * 2) {
            for (int i = 1; i <= n - 3; i++) {
                middleRows = "|" + reapetsStr(" ", n * 2 - 2) + "|";
                System.out.println(middleRows);

            }
        } else {
            for (int i = 1; i <= n - 3; i++) {
                middleRows = "|" + reapetsStr(" ", n * 2 - 2) + "|";
                System.out.println(middleRows);

            }
        }

        if  (n >= 5 && (n / 2) + (n / 2) + (n / 2) + 4 < n * 2) {
            exeption = "|" + reapetsStr(" ", n / 2 + 1)
                    + reapetsStr("_", n / 2 + diff)
                    + reapetsStr(" ", n / 2 + 1) + "|";
            System.out.println(exeption);
        }else if (n >= 5){
            exeption = "|" + reapetsStr(" ", n / 2 + 1)
                    + reapetsStr("_", n / 2)
                    + reapetsStr(" ", n / 2 + 1) + "|";
            System.out.println(exeption);
        }


        if (n < 5)

        {
            lastRow = "\\" + reapetsStr("_", n / 2)
                    + "/" + "\\" + reapetsStr("_", n / 2) + "/";
        } else if (n >= 5 && (n / 2) + (n / 2) + (n / 2) + 4 < n * 2)

        {
            lastRow = "\\" + reapetsStr("_", n / 2)
                    + "/" + reapetsStr(" ", n / 2 + diff)
                    + "\\" + reapetsStr("_", n / 2)
                    + "/";
        } else

        {
            lastRow = "\\" + reapetsStr("_", n / 2)
                    + "/" + reapetsStr(" ", n / 2)
                    + "\\" + reapetsStr("_", n / 2)
                    + "/";
        }
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